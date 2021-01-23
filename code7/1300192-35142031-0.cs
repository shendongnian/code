     public override Task OnConnected()
            {
                Clients.Caller.Register();
    
    
                return base.OnConnected();
            }
