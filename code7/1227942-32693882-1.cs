	public async void SomeEventHandler(object sender, EventArgs e)
	{
		var firstUiProperty = GetUIProperty1Async();
		var secondUiProperty = GetUIProperty2Async();
		await TaskEx.WhenAll(firstUiProperty, secondUiProperty);
	}
	
