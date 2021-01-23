    //in SomeClass
    public Client Client = new Client();
    public Dictionary<string, string> Channels = new Dictionary<string, string>();
    
    public SomeClass()
    {
        Channels.Add("main", "#channelName");
        Channels.Add("secundary", "#secondChannelName");
    }
    
    //in Client
    public Channel GetChannel(string channelName)
    { //return a channel specific to this Client.
    }
