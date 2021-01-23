    public override Task OnConnected()
    {
        var us=new UserConnection();
        us.UserName = Context.QueryString['username'];
        us.ConnectionID =Context.ConnectionId;
        uList.Add(us);
        return base.OnConnected();
    }
