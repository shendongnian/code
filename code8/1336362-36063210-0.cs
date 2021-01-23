    public async Task JoinRoom(string room_id)
    {
        await this.Groups.Add(this.Context.ConnectionId, room_id);
    }
    
    public async Task UnJoinRoom(string room_id)
    {
        await this.Groups.Remove(this.Context.ConnectionId, room_id);
    }
