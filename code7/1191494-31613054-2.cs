    public override OnConnected()
    {
      // Increase the active user count in the db 
      IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
      Clients.All.broadcastCount(DB.GetCount());
      return base.OnConnected();
    }
    public override OnDisconnected() 
    {
        //Decrease the connected user count in the db
      IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ServerHub>();
      Clients.All.broadcastCount(DB.GetCount());
      return base.OnDisconnected();
    }
