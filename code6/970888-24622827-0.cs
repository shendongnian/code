	public Dictionary<string, Func<Channel>> Channels
		= new Dictionary<string, Func<Channel>>();
	
	public SomeClass()
	{
		Channels.Add("main", () => _client.GetChannel("#channelName"));
		Channels.Add("secundary", () => _client.GetChannel("#secondChannelName"));
	}
