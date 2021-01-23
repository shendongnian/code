    var indicator = new ActivityIndicator ();
    var none = new Button {
        HorizontalOptions = LayoutOptions.Center,
        Text = "No pager indicator",
        Command = new Command(() => {
            indicator.IsRunning = true;
            indicator.IsVisible = true;
            Device.StartTimer(Timespan.FromSeconds(2.5),()=>
            {
                indicator.IsRunning = false;
                indicator.IsVisible = false;
                Navigation.PushAsync(new HomePage(CarouselLayout.IndicatorStyleEnum.None));
                return false;
            });
        });
           
    };
