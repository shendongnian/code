	protected override void OnAppearing()
	{
		base.OnAppearing();
		MessagingCenter.Subscribe<object, string>(this, "ShowAlertMessage", (sender, arg) =>
		{
			DisplayAlert("Alert", arg, "Ok");
		});
	}
	protected override void OnDisappearing()
	{
		base.OnDisappearing();
		MessagingCenter.Unsubscribe<object>(this, "ShowAlert");
	}
