    private Record _selectedRecord;
    public Record SelectedRecord
    {
        get { return _selectedRecord; }
        set
        {
            _selectedRecord = value;
            OnPropertyChanged();
            // Call your DoWork() method here
            this.DoWork();
        }
    }
