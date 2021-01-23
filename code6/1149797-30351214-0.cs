    HubConnection _connection = new HubConnection(Properties.Settings.Default.UserLoginDataSource);
    IHubProxy _hub;
    void TryConnectingDataSource()
    {
     try
     {
       _connection.Stop();
       _connection.Dispose();
    
       _connection = new HubConnection(Properties.Settings.Default.UserLoginDataSource);
       _connection.StateChanged += connection_StateChanged;
       _hub = _connection.CreateHubProxy("myHub");
       _connection.Start().Wait();
    
       if (_connection.State == ConnectionState.Connected)
       {
          _hub.On("myHubCallback", new Action<Dictionary<string, Entities.Permissions.UserTypes>>(GetUserLoginList));
          _hub.Invoke("myHubMethod");
       }
     }
     catch (Exception x)
     {
       EventLogger.LogError(x);
     }
    }
