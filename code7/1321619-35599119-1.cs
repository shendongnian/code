    public void DeviceCollectionChanged()
    {
        RaisePropertyChanged(() => DeviceCollection);
        RaisePropertyChanged(() => DisconnectedDevices);
       // or RaisePropertyChanged("DisconnectedDevices"); Whichever works
    }
