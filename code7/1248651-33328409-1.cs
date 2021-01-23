    public async Task JoinGame(int id)
    {
        await Groups.Add(Context.ConnectionId, id);
        Clients.All.newPlayer(id);
    }
   
