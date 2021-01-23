    <ComboBox x:Name="comboBox" ItemsSource="{Binding Directory}" 
         SelectedItem="{Binding SelectedHost}" />
    public event PropertyChangedEventHandler PropertyChanged;
    HostEntry _selectedHost;
    public HostEntry SelectedHost
    {
      get { return _selectedHost; }
      set
      {
        _selectedHost = value;
        RaiseNotifyPropertyChanged();
        // What is this? propertys should not do things like this CreateWriter();
      }
    }
    // This method is called by the Set accessor of each property.
    // The CallerMemberName attribute that is applied to the optional propertyName
    // parameter causes the property name of the caller to be substituted as an argument.
    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
