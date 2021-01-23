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
                 rootFrame.Navigate(typeof(MainPage));
                 MainPage page = rootFrame.Content as MainPage;
                 switch (item)
                 {
                     case "one":
                         page.StepOne(0);
                         break;
    
                     case "two":
                         page.StepOne(1);
                         break;
    
                     default:
                         break;
                 }
             }
         }
     }
     Window.Current.Activate();
    }
