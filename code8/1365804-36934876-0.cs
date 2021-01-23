    public DelegateCommand SaveCommand { get; private set; }
    
    public SampleViewModel()
    {
        SaveCommand = new DelegateCommand(Save);
    }
    
    private void Save()
    {
        // do something
    }
