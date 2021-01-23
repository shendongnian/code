    var splash = new SplashScreen(this);
    splash.Show(); 
    
    Thread thread = new Thread(new ThreadStart(Initialize));
    thread.SetApartmentState(ApartmentState.STA);
    thread.IsBackground = true;
    thread.Start();
    
    
    public void Initialize()
    {
        //move your long running logic from your app here..
        ChangeSplashScrnMessageText("Initialization Started");
        Thread.Sleep(1000);
        ChangeSplashScrnMessageText("Initialize finished");
    }
    public void ChangeSplashScrnMessageText(string messageText)
    {
        splash.messageLabel.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(() => { splash.messageLabel.Content = messageText; }));
    }
