            private Choices onOff = new Choices();
            private SpeechRecognitionEngine alwaysOnListener = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
    
            public void myConstructor()
            {
                //... other stuff
                
                onOff.Add(new string[] { "Hey Larry, start listening to me", "Stop Listening" });
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(onOff);
                Grammar g = new Grammar(gb);
    
                alwaysOnListener.LoadGrammar(g);
                alwaysOnListener.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(alwaysOnListener_RecognizeCompleted);
                alwaysOnListener.RecognizeAsync(RecognizeMode.Multiple);
            }
    
            private void alwaysOnListener_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
            {
                if (e.Result.Text.Equals("Stop Listening"))
                {
                    recEngine.RecognizeAsyncStop();
                    alwaysOnListener.RecognizeAsync(RecognizeMode.Multiple);
                }
                else if (e.Result.Text.Equals("Hey Larry, start listening to me"))
                {
                    recEngine.RecognizeAsync(RecognizeMode.Multiple);
                    alwaysOnListener.RecognizeAsyncStop();
                }
            } 
