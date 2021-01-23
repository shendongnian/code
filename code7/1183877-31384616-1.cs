    public partial class Form1 : Form
        {
            private Choices onOff = new Choices();
            private Choices recChoices = new Choices();
            private SpeechRecognitionEngine alwaysOnListener = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            private SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
    
            public Form1()
            {
                InitializeComponent();
                onOff.Add(new string[] {"Hey Larry start listening to me"});
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(onOff);
                Grammar g = new Grammar(gb);
                alwaysOnListener.LoadGrammar(g);
                alwaysOnListener.SpeechRecognized += alwaysOnListener_SpeechRecognized;
    
    
                recChoices.Add(new string[] {"Stop Listening"});
                GrammarBuilder gb2 = new GrammarBuilder();
                gb2.Append(recChoices);
                Grammar recGrammar = new Grammar(gb2);
                recEngine.LoadGrammar(recGrammar);
                recEngine.SpeechRecognized += recEngine_SpeechRecognized;
            }
    
            void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                if (e.Result.Text.Equals("Stop Listening"))
                {
                    recEngine.RecognizeAsyncStop();
                    alwaysOnListener.RecognizeAsync(RecognizeMode.Multiple);
                }
                
            }
    
            void alwaysOnListener_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
            {
                if (e.Result.Text.Equals("Hey Larry start listening to me"))
                {
                    recEngine.RecognizeAsync(RecognizeMode.Multiple);
                    alwaysOnListener.RecognizeAsyncStop();
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                alwaysOnListener.EmulateRecognize("Hey Larry start listening to me");
            }
    
            private void btnStop_Click(object sender, EventArgs e)
            {
                recEngine.EmulateRecognize("Stop Listening");
            }
        }
