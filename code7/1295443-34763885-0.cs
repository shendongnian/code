    Window.Current.CoreWindow.Activated += (sender, args) =>
    {
        if (args.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
        {
            System.Diagnostics.Debug.WriteLine("Deactivated " + DateTime.Now);
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Activated " + DateTime.Now);
        }
    };
