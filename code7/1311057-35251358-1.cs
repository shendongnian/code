    class Program
    {
        private static SpeechRecognitionEngine sre;
        static void Main(string[] args)
        {
            RestartRec();
            Console.ReadKey();
        }
        static void RestartRec()
        {
            if (sre != null) sre.Dispose();
            
            //Preload DB entities once, store in private field and add them again here
            Choices userReplies = new Choices();
            userReplies.Add("hello");
            sre = new SpeechRecognitionEngine();
            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(userReplies);
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            sre.SetInputToDefaultAudioDevice();
            // Start recognition.
            sre.Recognize();
        }
        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
            RestartRec();
        }
    }
