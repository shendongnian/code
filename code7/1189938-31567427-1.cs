    private void SomeCode()
    {
        int id;
        // do other stuff
        
        Dispatcher.BeginInvoke(new Action(() =>
            {
                GetStationCoordinates(id);
            }),
            DispatcherPriority.Loaded);
    }
