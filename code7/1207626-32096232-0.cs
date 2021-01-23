    private TabControlViewModel _tabControlViewModel;
    
    public TabControlViewModel TabControlViewModel
    {
        get { return _tabControlViewModel; }
        set
        {
            _tabControlViewModel = value;
            //Init here
            NotifyOfPropertyChange(() => TabControlViewModel);
        }
    }
