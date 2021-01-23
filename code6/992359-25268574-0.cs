    DatabaseInfo.PropertyChanged += DataBasePropertyChanged;
...
    private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        NotifyPropertyChanged(m => m.DatabaseInfo);
    }
