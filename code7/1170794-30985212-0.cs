    public DateTimeOffset DateTimeOffsetTest
    {
        get { return _dateTimeOffsetTest; }
        set
        {
            _dateTimeOffsetTest = value; 
            OnPropertyChanged();  // LOOK HERE
        }
    }
