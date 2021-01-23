    SpeechSynthesizer sr = new SpeechSynthesizer();
    sr.Rate = 1;
    sr.Volume = 100;
    //the following starts a background thread
    Task.Factory.StartNew(
      () =>
         {
            //this anon method will be run in a background thread
            sr.Speak();
            SpeakCallBack();
         });
