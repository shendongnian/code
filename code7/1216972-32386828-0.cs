		var indicator = new ActivityIndicator ();
		var none = new Button {
			HorizontalOptions = LayoutOptions.Center,
			Text = "No pager indicator",
			Command = new Command(async() => {
				indicator.IsRunning = true;
				indicator.IsVisible = true;
				await Task.Delay(2500);
				indicator.IsRunning = false;
				indicator.IsVisible = false;
				Navigation.PushAsync(new HomePage(CarouselLayout.IndicatorStyleEnum.None));
			})
		};
