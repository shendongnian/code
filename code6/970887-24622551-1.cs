    // to run it in a different class:
    Channel thisChannel = someClassInstance.GetChannelObject("#main");
    // in SomeClass:
    public Channel GetChannelObject(string channelID) {
        string channelName;
        Channels.tryGetValue(channelID, out channelName);
        Channel thisChannel = Client.GetChannel(channelName);
        return(thisChannel);
    }
