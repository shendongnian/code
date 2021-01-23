	public Form()
	{
		this.Load += OnLoadHandler;
	}
	
	public async void OnLoadHandler(object sender, EventArgs e)
	{
		var result = await RenewAuthenticationAsync();
		// Store the result here
	}
