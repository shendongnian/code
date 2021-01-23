    protected void PopulateCurrentDevices(IEnumerable<String> stringsFromWherever)
    {
        CurrentDevices.Clear();
        foreach (var device in stringsFromWherever)
        {
            var dovm = new DeviceOptionViewModel() {
                    CurrentDevice = device,
                    AvailableDevices = this.availableDevices
                };
            dovm.PropertyChanged += DeviceOption_PropertyChangedHandler;
            CurrentDevices.Add(dovm);
        }
    }
    protected void DeviceOptionViewModel_PropertyChangedHandler(object sender, 
         PropertyChangedEventArgs e)
    {
        var dopt = sender as DeviceOptionViewModel;
        if (e.PropertyName == nameof(DeviceOptionViewModel.CurrentDevice))
        {
            //  Do stuff
        }
    }
