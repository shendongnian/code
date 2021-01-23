	public DbContext()
		: base("Name = ConntectionName")
	{
		this.Configuration.ProxyCreationEnabled = false;
		this.Configuration.LazyLoadingEnabled = false;
	}
