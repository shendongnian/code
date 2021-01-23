	public async void SomeEventHandler(object sender, EventArgs e)
	{
		var firstUiProperty = GetUIProperty1Async();
		var secondUiProperty = GetUIProperty2Async();
		await Task.WhenAll(firstUiProperty, secondUiProperty);
	}
