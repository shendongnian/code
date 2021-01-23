    string _inputRead;
    public string InputRead // fixing naming
    {
        get { return _inputRead; }
        set
        {
            _inputRead = plc.InputImage[1].ToString();
            OnPropertyChanged("inputread");
        }
    }
