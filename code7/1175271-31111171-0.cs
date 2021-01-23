    public async Task<Channel> Subscribe(string channelName)
    {
        if (_connection.State != ConnectionState.Connected)
            throw new PusherException("You must wait for Pusher to connect before you can subscribe to a channel", ErrorCodes.NotConnected);
    
        if (Channels.ContainsKey(channelName))
        {
            return Channels[channelName];
        }
    
        // If private or presence channel, check that auth endpoint has been set
        var chanType = ChannelTypes.Public;
    
        if (channelName.ToLower().StartsWith("private-"))
            chanType = ChannelTypes.Private;
        else if (channelName.ToLower().StartsWith("presence-"))
            chanType = ChannelTypes.Presence;
    
        return await SubscribeToChannel(chanType, channelName).ConfigureAwait(false); 
    }
