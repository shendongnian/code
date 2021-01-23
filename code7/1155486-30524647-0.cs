    protected override void OnActivated(IActivatedEventArgs args)
    {
        if (args.Kind == ActivationKind.VoiceCommand)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            VoiceCommandActivatedEventArgs vcArgs = (VoiceCommandActivatedEventArgs)args;
 
            //check for the command name that launched the app
            string voiceCommandName = vcArgs.Result.RulePath.FirstOrDefault();
 
            switch (voiceCommandName)
            {
                case "ViewEntry":
                    rootFrame.Navigate(typeof(ViewDiaryEntry), vcArgs.Result.Text);
                    break;
                case "AddEntry":
                case "EagerEntry":
                    rootFrame.Navigate(typeof(AddDiaryEntry), vcArgs.Result.Text);
                    break;
            }
        }
    }
