    public void sRecognize_SpeechRecognized (object sender, SpeechRecognizedEventArgs e)
    {
        SemanticValue semantics = e.Result.Semantics;
        RecognitionResult result = e.Result;
        if (listening)
        {
            // This if statement
            if (greeting.Contains(result.Text))
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
