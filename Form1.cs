using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Speech_to_text_Artificial_Intelligence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
        SpeechSynthesizer voice = new SpeechSynthesizer();

        private void Form1_Load(object sender, EventArgs e)
        {

            voice.SelectVoiceByHints(VoiceGender.Female);

            string[] commend ={"Hi","How Are you","What is the captital of bangladesh","What is your name","bye","Bro what's UP" ,"what is jewel", "What is google","What is Facebook" };

            Choices choices = new Choices(commend);

            GrammarBuilder gb = new GrammarBuilder(choices);

            Grammar grammar = new Grammar(gb);
            sre.LoadGrammarAsync(grammar);
            sre.SetInputToDefaultAudioDevice();
            sre.RecognizeAsync(RecognizeMode.Multiple);

            sre.SpeechRecognized += Sre_SpeechRecognized;

        }

        private void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string human = e.Result.Text;

            string computer = "";

            switch (human)
            {
                case "Hi":
                    computer = "hello";
                    break;
                case "How Are you":
                    computer = "I am well thanks ";
                    break;
                case "What is your name":
                    computer = "my name is Computer Assistant this program create with c#";
                    break;
                case "bye":
                    computer = "Tok to  meet again soon";
                    break;

                case "What is the captital of bangladesh":
                    computer = "The Captial of Bangladesh Is Dhaka";
                    break;

                case "Bro what's UP":
                    computer = "Yea i am very good bap bro";
                    break;

                case "jewel":
                    computer = "jewel is a good boy";
                    break;

                case "What is google":
                    computer = "Google is a search engine that can be employed to find a variety of information such as websites, pictures, maps or even just the answer to the crossword clue that’s been driving you mad all morning!";
                    break;
                case "What is Facebook":
                    computer = "Facebook, Inc. is an American online social media and social networking service company. It is based in Menlo Park, California. It was founded by Mark Zuckerberg,";
                    break;









            }

            richTextBox1.AppendText("Human: " +human +"\n");
            richTextBox1.AppendText("Computer: " + computer + "\n");
            voice.SpeakAsync(computer);
            




        }
    }
}
