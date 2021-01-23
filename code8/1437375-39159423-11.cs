	public MyContext(bool enableLazyLoading) 
		: this()
	{
		this.Configuration.LazyLoadingEnabled = enableLazyLoading;
		this.Configuration.ProxyCreationEnabled = enableLazyLoading;
	}
