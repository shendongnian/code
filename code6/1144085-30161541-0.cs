    // invoke this method only once when you setup the whole system
    private void init() {
            JARVIS= new SpeechSynthesizer();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("test")));
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder("good bye")));
            _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice();
    }
    // Recognizer is already configured, just speak and recognize
    private void simpleButton1_Click(object sender, EventArgs e)
    {
            JARVIS.Speak("How can i help you sir?");
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
    }
    // Handler for recognition results
    private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
            if (e.Result.Text == "test") { // e.Result.Text contains the recognized text
                JARVIS.Speak("Test was successful!!");
            }
            if (e.Result.Text == "good bye") {
                JARVIS.Speak("Good Bye sir");
            }
    }
