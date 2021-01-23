    private static void CallMyService()
      {
        string address = "net.pipe://localhost/MyApp/NamedPipeBindingHost";
        EndpointAddress ep = new EndpointAddress(adress);
        var channelFactory = new ChannelFactory<IMyService>(GetNamedPipeBindings(), ep);
        IMyService myChannel= channelFactory.CreateChannel();
        bool error = true;
        try
         {
          myChannel.PerformOperation();
          ((IClientChannel)myChannel).Close();
          error = false;
         }
       finally
        {
          if (error)
          {
           ((IClientChannel)myChannel).Abort();
          }
        }
      }
    private NamedPipeBinding GetNamedPipeBindings()
    {
      NamedPipeBinding  binding = new NamedPipeBinding (NetNamedPipeSecurityMode.None);
    
      binding.OpenTimeout = TimeSpan.FromMinutes(2); 
      b.closeTimeout = TimeSpan.FromMinutes(1);
      b.SendTimeout = TimeSpan.FromMinutes(10);
    
      return binding;
    }
