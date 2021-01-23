    public override Task OnConnected()
    {
        var us=new user();
        us.Source = Context.QueryString['source'];
        us.ConnectionID=Context.ConnectionId;
        userList.Add(us);
        return base.OnConnected();
    }
