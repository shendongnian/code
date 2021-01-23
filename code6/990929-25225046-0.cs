    public string SelectedName
    {
      get { return _selectedName; }
      set
      {
        _selectedName = value;
        OnPropertyChanged();
        SelectedNameDetails = new NotifyTaskCompletion<SelectedNameData>(FetchNameDataAsync());
      }
    }
    public NotifyTaskCompletion<SelectedNameData> SelectedNameDetails
    {
      get { return _selectedNameDetails; }
      set { _selectedNameDetails = value; OnPropertyChanged(); }
    }
