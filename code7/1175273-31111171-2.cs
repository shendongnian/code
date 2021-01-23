    public Task<Channel> Subscribe(string channelName)
    {
        if (_connection.State != ConnectionState.Connected)
            throw new PusherException("You must wait for Pusher to connect before you can subscribe to a channel", ErrorCodes.NotConnected);
    
        if (Channels.ContainsKey(channelName))
        {
            return Task.FromResult(Channels[channelName]);
        }
    
        // If private or presence channel, check that auth endpoint has been set
        var chanType = ChannelTypes.Public;
    
        if (channelName.ToLower().StartsWith("private-"))
            chanType = ChannelTypes.Private;
        else if (channelName.ToLower().StartsWith("presence-"))
            chanType = ChannelTypes.Presence;
    
        return SubscribeToChannel(chanType, channelName); //await is not needed here
    }
    private async Task<Channel> SubscribeToChannel(ChannelTypes type, string channelName)
    {
        switch (type)
        {
            case ChannelTypes.Public:
                Channels.Add(channelName, new Channel(channelName, this));
                break;
            case ChannelTypes.Private:
                AuthEndpointCheck();
                Channels.Add(channelName, new PrivateChannel(channelName, this));
                break;
            case ChannelTypes.Presence:
                AuthEndpointCheck();
                Channels.Add(channelName, new PresenceChannel(channelName, this));
                break;
        }
    
        if (type == ChannelTypes.Presence || type == ChannelTypes.Private)
        {
            string jsonAuth = await _options.Authorizer.Authorize(channelName, _connection.SocketID)
             .ConfigureAwait(false); //do not capture the context!!
    
            var template = new { auth = String.Empty, channel_data = String.Empty };
            var message = JsonConvert.DeserializeAnonymousType(jsonAuth, template);
    
            _connection.Send(JsonConvert.SerializeObject(new { @event = Constants.CHANNEL_SUBSCRIBE, data = new { channel = channelName, auth = message.auth, channel_data = message.channel_data } }));
        }
        else
        {
            // No need for auth details. Just send subscribe event
            _connection.Send(JsonConvert.SerializeObject(new { @event = Constants.CHANNEL_SUBSCRIBE, data = new { channel = channelName } }));
        }
    
        return Channels[channelName];
    }
