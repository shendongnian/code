    public ICommand SetTestLabelCommand { get; set; }
    string _testLabel;
    public string TestLabel
    {
        get
        {
            return _testLabel;
        }
        set
        {
            _testLabel = value;
            RaisePropertyChanged("TestLabel");
        }
    }
    
    string _firstLabel;
    public string FirstLabel
    {
        get
        {
            return _firstLabel;
        }
        set
        {
            _firstLabel= value;
            RaisePropertyChanged("FirstLabel");
        }
    }
    
    string _secondLabel;
    public string SecondLabel
    {
        get
        {
            return _secondLabel;
        }
        set
        {
            _secondLabel= value;
            RaisePropertyChanged("SecondLabel");
        }
    }
    
    SetTestLabelCommand = new RelayCommand<string>(SetTestLabel);
    
    private void SetTestLabel(string value)
    {
        TestLabel = value;
    }
