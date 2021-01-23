	public async void SomeEventHandler(object sender, EventArgs e)
	{
		var response = await server.SendMessageAsync("HelloWorld");
		// Do stuff with response here
	}
	
