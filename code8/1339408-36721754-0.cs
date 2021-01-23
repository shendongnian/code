     public Page1VM(IDataService serv)
        {
            Page1SubViewModel = Locator.SubViewModel_Page1;
        }    
    private SubViewModel _Page1SubViewModel;
    public SubViewModel Page1SubViewModel
    {
            get
            {
                return _Page1SubViewModel;
            }
            set
            {
                if (_Page1SubViewModel == value)
                    return;
                _Page1SubViewModel = value;
                RaisePropertyChanged();
            }
        }
    
