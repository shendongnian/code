	public ProviderFactory(Func<IProvider> bingProvider, Func<IProvider> googleProvider) { .. }
	public IProvider Get(string provider) {
		switch (provider) {
			case "Bing": return bingProvider();
			case "Google": return googleProvider();
			default: throw new ArgumentOutOfRangeException();
		}
	}
