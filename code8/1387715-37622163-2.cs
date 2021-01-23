	protected override void OnAppearing()
	{
		base.OnAppearing();
		MessagingCenter.Subscribe<object, string>(this, "ShowAlertMessage", (sender, msg) =>
		{
            Device.BeginInvokeOnMainThread(() => {
                MainPage.DisplayAlert("Push message", msg, "OK"); 
            });
		});
	}
	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		MessagingCenter.Unsubscribe<object>(this, "ShowAlertMessage");
	}
