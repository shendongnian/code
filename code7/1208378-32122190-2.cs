    public MainViewModel()
    {
        SelectionChangedCommand=
            new RelayCommand(() => OnSelectionChange()));
    }
    
    public RelayCommand SelectionChangedCommand {get;set;}
