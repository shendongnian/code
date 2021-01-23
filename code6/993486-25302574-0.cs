    void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
    {
      string speech = e.Result.Text;
      if (speech == "Start listening") {
          bAbleToListen = true; //resume listening
          BRIAN.SpeakAsync("I am online and ready");
      }
      if (!bAbleToListen) return;
       
      switch(...) {
         //your code
      }
    }
