    IEventAggregator.GetEvent<PubSubEvent<HardwareLoaded>>().Subscribe(x =>
    {
        if (!x.HardwareOK)
        {
            MessageBox.Show("There was an issue loading hardware. See Log");
        }
    
        LoadingVisibility = Visibility.Collapsed;
    }, ThreadOption.UIThread);
