    protected override void OnActivated(IActivatedEventArgs args)
    {
        if (args.Kind == ActivationKind.Protocol)
        {
            ProtocolActivatedEventArgs protocolArgs =
               args as ProtocolActivatedEventArgs;
            var rootFrame = new Frame();
            rootFrame.Navigate(typeof(BlogItems), args);
            Window.Current.Content = rootFrame;
        }
        Window.Current.Activate();
    }
