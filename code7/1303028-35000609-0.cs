    IQueryable<Peer> peers = dbContext.peers;
    if(isConnected.HasValue)
    {
        var isConnectedValue = isConnected.Value;
        peers = peers.Where(m => m.IsConnected == isConnectedValue);
    }
    return peers.ToList();
