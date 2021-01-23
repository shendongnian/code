    static void worker_DoWork(object sender,DoWorkEventArgs e) 
    { 
      string strClientId = "";
      var setClientId = new Action<string>(v => { strClientId = v; });
      setClientId("2211");
      Authenticate(setClientId); 
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
