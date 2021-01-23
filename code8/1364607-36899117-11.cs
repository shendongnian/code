	public ProviderDispatcher(IProvider bing, IProvider google) { .. }
    public void DoSomething(string provider, ProviderData data) {
        this.Get(provider).DoSomething(data);
    }
	private IProvider Get(string provider) {
		switch (provider) {
			case "Bing": return this.bing;
			case "Google": return this.google;
			default: throw new ArgumentOutOfRangeException();
		}
	}
