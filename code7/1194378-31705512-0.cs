    public MainViewModel()
    {
        // Constructor
        if (SelectedProvider != null)
            SelectedProvider.PropertyChanged += SelectedProvider_PropertyChanged;
    }
    private void SelectedProvider_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        SaveProviderCommand.RaiseCanExecuteChanged();
    }
