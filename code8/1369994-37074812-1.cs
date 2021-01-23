    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)this.DataContext).PropertyChanged += OnDataContextPropertyChanged;
        }
    }
    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        if (this.DataContext is INotifyPropertyChanged)
        {
            ((INotifyPropertyChanged)this.DataContext).PropertyChanged -= OnDataContextPropertyChanged;
        }
    }
    private void OnDataContextPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        // You could also just update every time something is changed.
        // As an example you could check for the "Name" property being changed.
        if (e.PropertyName == nameof(Device.Name))
        {
            title.Text = this.DataContext.Name;
        }
    }
