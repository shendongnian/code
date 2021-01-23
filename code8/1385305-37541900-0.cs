    string _testString;
    
    public string TestString
    {
        get { return _testString; }
        set
        {
            _testString = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TestString)));
        }
    }
