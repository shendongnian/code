    public void sRecognize_SpeechRecognized (object sender, SpeechRecognizedEventArgs e)
    {
        SemanticValue semantics = e.Result.Semantics;
        RecognitionResult result = e.Result;
        if (listening)
        {
            if (result.Grammar.Equals(greetingg))
            {
                sfos.Speak("hello");
            }
            else if (e.Result.Text == "tell me a joke")
            {
                chip.Speak("Sure.");
                chip.Speak(jokelist[new Random().Next(jokelist.Count)]);
            }
        }
    }
