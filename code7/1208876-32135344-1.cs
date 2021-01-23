    private _selectedConfigurationProfile;
    public SimpleData SelectedConfigurationProfile
    {
        get { return _selectedConfigurationProfile; }
        set
        {
            if (_selectedConfigurationProfile != value)
            {
                _selectedConfigurationProfile = value;
                //NotifyPropertyChanged("SelectedConfigurationProfile"); if needed
            }
        }
    }
    public void MethodThatSetsDefault()
    {
        SelectedConfigurationProfile = GridConfigurationProfiles.FirstOrDefault(q => q.IsDefault);
    }
