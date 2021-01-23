    sfBusyIndicator = new SfBusyIndicator(this);
        sfBusyIndicator.TextColor = Color.Rgb(62,101,254);
        sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;
        sfBusyIndicator.ViewBoxWidth = 200;
        sfBusyIndicator.ViewBoxHeight = 200;
        sfBusyIndicator.TextSize = 60;
        sfBusyIndicator.Title = "Loading ... Please Wait ...";
    sfBusyIndicator.IsBusy = true;
    FrameLayout busyIndicatorHolder = new FrameLayout(this);
    busyIndicatorHolder.AddView(sfBusyIndicator);
    // a Lot of work is done here for around 15 seconds. a database connection is 
    called.
    sfBusyIndicator.IsBusy = false;
