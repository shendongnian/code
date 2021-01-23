    protected override void OnActivated(IActivatedEventArgs args)
            {
                if (args.Kind == ActivationKind.ToastNotification)
                {
                    var toastArgs = args as ToastNotificationActivatedEventArgs;
                    var arguments = toastArgs.Argument;
    
                    if (arguments == "ARG")
                    {
                        Frame rootFrame = Window.Current.Content as Frame;
                        if (rootFrame == null)
                        {
                            rootFrame = new Frame();
                            Window.Current.Content = rootFrame;
                        }
                        rootFrame.Navigate(typeof(YOURPAGE));
                        Window.Current.Activate();
                    }
                }
            }
