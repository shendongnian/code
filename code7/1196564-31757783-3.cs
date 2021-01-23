    static void worker_DoWork(object sender,DoWorkEventArgs e) 
    { 
      string strClientId = "2211";
      Authenticate(v => { strClientId = v; }); 
    }
    static void Authenticate(Action<string> setClientId) 
    {
      Timer timer = new Timer(500); 
      timer.Elapsed += (sender, e) => Authenticates_Timer(sender, e, setClientId); 
      timer.Start();    
    }
    static void Authenticates_Timer(object sender, ElapsedEventArgs e, Action<string> setClientId)
    { 
      setClientId("");
    }
