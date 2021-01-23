    public MyPage()
    {
        // Constructor
        this.Loaded += OnLoaded;
    }
    
    private void OnLoaded(object sender, RoutedEventArgs args)
    {
        Loaded -= OnLoaded;
        ButtonAutomationPeer peer = new ButtonAutomationPeer(button);
        IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
        invokeProv.Invoke();
    }
