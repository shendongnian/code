	public MyContext : base("Name=MyContext")
	{
		// Turn off lazy loading and proxy creation
		this.Configuration.LazyLoadingEnabled = false;
		this.Configuration.ProxyCreationEnabled = false;
	}
