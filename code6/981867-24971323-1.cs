    protected async override void OnInvoke(ScheduledTask task)
    {
        Deployment.Current.Dispatcher.BeginInvoke(() =>
        {
            LiveTileViewModel viewModel = new LiveTileViewModel();
            await viewModel.getWeatherForTileLocation();
        }
    }
