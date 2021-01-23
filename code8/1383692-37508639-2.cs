	var semaphone = new SemaphoreSlim(1);
	MessagingCenter.Subscribe<object>(this, "ClearStackLayout",  async (sender) =>
	{
		await semaphone.WaitAsync();
		Device.BeginInvokeOnMainThread(() =>
		{
			_choices.Children.Clear();
		});
		semaphone.Release();
	});
	MessagingCenter.Subscribe<object, View>(this, "AddToStackLayout", async (sender, arg) =>
	{
		await semaphone.WaitAsync();
		Device.BeginInvokeOnMainThread(() =>
		{
			_choices.Children.Add(arg);
		});
		semaphone.Release();
	});
