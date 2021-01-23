     public override Task OnConnected()
            {
                string connectionId = Context.ConnectionId;
                IPrincipal user = Context.User;
    
                //Save connection.
                _clientManager.AddToCorrectGroup(user, connectionId;
    
                return base.OnConnected();
            }
