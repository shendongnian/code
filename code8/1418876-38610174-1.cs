    public ChildViewModel()
    {
        ChildCommand = new RelayCommand<string>((s) => Test(s));
    }
    
    public RelayCommand<string> ChildCommand { get; set; }
    
    private void Test(string s)
    {
        throw new NotImplementedException();
    }
