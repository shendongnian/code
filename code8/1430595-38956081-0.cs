    private string _ut1Value;
    private string _ut2Value;
    public string Ut1Value
    {
        get
        {
            return _ut1Value;
        }
        set
        {
            if (_ut1Value!= value)
            {
                _ut1Value= value;
                OnPropertyChanged("Ut1Value");
            }
        }
    }
    public string Ut2Value
    {
        get
        {
            return _ut2Value;
        }
        set
        {
            if (_ut2Value!= value)
            {
                _ut2Value= value;
                OnPropertyChanged("Ut2Value");
            }
        }
    }
    public ICommand CreateTheThingCommand
    {
        get { return new RelayCommand(CreateTheThing); }
    }
    private void CreateTheThing()
    {
        Object newObject = new Object(_ut1Value, _ut2Value, false);
        // Do whatever with your new object
    }
