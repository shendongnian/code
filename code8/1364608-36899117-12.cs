    class ProviderDispatcherProxy : IProvider {
        public ProviderDispatcherProxy(Func<IProvider> bingProvider, 
            Func<IProvider> googleProvider,
            IProviderContext providerContext) { ... }
        void IProvider.DoSomething(ProviderData data) {
            // Dispatch to the correct provider
            this.GetCurrentProvider.DoSomething(data);
        }
		private IProvider GetCurrentProvider() =>
			switch (this.providerContext.CurrentProvider) {
				case "Bing": return this.bingProvider();
				case "Google": return this.googleProvider();
				default: throw new ArgumentOutOfRangeException();
			}
		};
    }
    class AspNetProviderContext : IProviderContext {
        public CurrentProvider => HttpContext.Current.Request.QueryString["provider"];
    }
