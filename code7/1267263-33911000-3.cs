	public async void SomeOtherEventHandler()
	{
		var m = new M();
		m.X += FooAsync;
		m.OnFoo();
		m.X -= FooAsync;
		m.OnFoo();
	}
	
	public async void FooAsync(object sender, EventArgs e)
	{
		await Task.Delay(1000);
		Debug.WriteLine("Yay event handler");
	}
