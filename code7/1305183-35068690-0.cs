     public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;
    
            Groups.Add(Context.ConnectionId, name);
    
            Clients.Group(name).newMessage("Hello world!"); //Welcome message to current user
    
            return base.OnConnected();
        }
