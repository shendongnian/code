    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (this.myDevice is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)this.myDevice).PropertyChanged += OnMyDevicePropertyChanged;
        }
    }
    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (this.myDevice is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)this.myDevice).PropertyChanged -= OnMyDevicePropertyChanged;
        }
    }
    private void OnMyDevicePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // You could also just update every time something is changed.
        // As an example you could check for the "Name" property being changed.
        if (e.PropertyName == nameof(Device.Name))
        {
            title.Text = this.myDevice.Name;
        }
    }
