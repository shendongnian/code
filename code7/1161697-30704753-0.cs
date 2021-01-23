    private async void speakSomething(string message)
    {
      SpeechSynthesizer sr = new SpeechSynthesizer();
      sr.Rate = 1;
      sr.Volume = 100;
      await sr.Speak(message);
    }
