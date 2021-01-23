    SpinnerItem _selectedNumberPlayers;
    public SpinnerItem SelectedNumberPlayers
    {
        get { return _selectedNumberPlayers; }
        set
        {
            if (_selectedNumberPlayers != value)
            {
                _selectedNumberPlayers = value;
                SettingsPreferences.SelectedNumberPlayers = _selectedNumberPlayers.Index;
                RaisePropertyChanged(() => SelectedNumberPlayers);
            }
        }
    }
