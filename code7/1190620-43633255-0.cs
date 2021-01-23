    private static void StartService()
    {
      try
       {
          string address = "net.pipe://localhost/MyApp/NamedPipeBindingHost";
          _serviceHost = new ServiceHost(typeof(MyService));
           NetNamedPipeBinding b = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
          _serviceHost.Open();
          b.OpenTimeout = TimeSpan.FromMinutes(2);
          b.closeTimeout = TimeSpan.FromMinutes(1);
          b.ReceiveTimeout = TimeSpan.FromMinutes(10);
    
         _serviceHost.AddServiceEndpoint(typeOf(IMyService), b, address);
         _serviceHost.Open();
       }
      catch(Exception ex)
       {
         LogError(ex);
         ExitApp();
       }
    }
    private static void ExitApp()
    {
     try
     {
       _serviceHost.Close();
     }
    catch(CommunicationException cex)
     {
       LogError(cex);
       _serviceHost.Abort();
     }
    finally
     {
       Application.Exit();
     }
