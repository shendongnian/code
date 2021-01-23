    private string count = null;
    protected override void OnActivated(IActivatedEventArgs args)
    {
        if (args.Kind == ActivationKind.VoiceCommand)
        {
            VoiceCommandActivatedEventArgs vargs = (VoiceCommandActivatedEventArgs)args;
            SpeechRecognitionResult res = vargs.Result;
            string cmdName = res.RulePath[0];
    
            if (cmdName == "step")
            {
                var interpretation = res.SemanticInterpretation;
                string item = interpretation.Properties["number"].FirstOrDefault();
                if (!string.IsNullOrEmpty(item))
                {
                    Frame rootFrame = Window.Current.Content as Frame;
                    if (rootFrame == null)
                    {
                        rootFrame = new Frame();
                        Window.Current.Content = rootFrame;
                    }
                    switch (item)
                    {
                        case "one":
                            count = "one";
                            break;
    
                        case "two":
                            count = "two";
                            break;
    
                        default:
                            count = null;
                            break;
                    }
                    rootFrame.Navigate(typeof(MainPage), count);
                }
            }
        }
        count = null;
        Window.Current.Activate();
    }
