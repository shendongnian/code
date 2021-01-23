	private static Dictionary<string, Func<string, object>> _bindingFactory = new Dictionary<string, Func<string, object>>()
	{
		{ "ServiceA", binding => new ChannelFactory<IServiceA>(binding).CreateChannel() },
		{ "ServiceB", binding => new ChannelFactory<IServiceB>(binding).CreateChannel() },
		{ "", binding => new ChannelFactory<IServiceC>(binding).CreateChannel() },
	};
	
	public static object CreateBinding(string binding, object service)
	{
		service = _bindingFactory[_bindingFactory.ContainsKey(binding) ? binding : ""](binding);
		OpenChannel(service);
		return service;
	}
