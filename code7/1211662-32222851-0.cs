	public async void MyEventHandler(object sender, EventArgs e)
	{
		await Task.Run(() => GetSystemInfo());
		// Here, you're back on the UI thread. 
		// You can open a splash screen.
	}
