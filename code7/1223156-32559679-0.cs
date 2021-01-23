    public void SendPrivateMessage(string receiverId, string message)
    {
       var to = ConnectedUsers.SingleOrDefault(x => x.ConnectionId == receiverId);
       var from = ConnectedUsers.SingleOrDefault(x => x.ConnectionId == Context.ConnectionId);
       
       if (to != null && from != null)
       {
    	   Clients.Client(receiverId).sendPrivateMessage(Context.ConnectionId, from.UserName, message);
    	   Clients.Caller.sendPrivateMessage(receiverId, from.UserName, message);
       }
    }
