    public void LoadingStatusChangedEventHandler(MapControl sender, Object o)
    {
        if (sender.LoadingStatus == MapLoadingStatus.Loaded)
        {
            // The map has stopped moving and finished rendering
            // If necessary, check that zoom level is different
            DoExpensiveOperation();
        }
    }
