    public FloorplanSearchViewModel(IErrorHandlerService inErrorHandler, INavigationService inNavigationService, 
                ISpaDataAdapter inDataAdapter, IAuthorizationService inAuthService)
    {            
        // Set the commands
        this.ShowStoreSetCommand = new DelegateCommand<IList<object>>(this.ShowStoreSet, this.CanShowStoreSet);
        this.SearchFloorplansCommand = new DelegateCommand(this.SearchFloorplans);
        this.ShowStatusChangeCommand = new DelegateCommand<IList<object>>(this.ShowStatusChange, this.CanShowStatusChange);
    
        // Set up the default values for the search
        this.StatusList = new List<object>();
        this.StatusList.Add(Enum.GetName(typeof(FloorplanData.FloorplanStatus), FloorplanData.FloorplanStatus.Pending));
        this.StatusList.Add(Enum.GetName(typeof(FloorplanData.FloorplanStatus), FloorplanData.FloorplanStatus.Review));
    
        //Initiate the SelectedFloorplan property
        SelectedFloorplan = new ObservableCollection<FloorplanData>();
        SelectedFloorplan.CollectionChanged += SelectedFloorplanOnCollectionChanged;
    }
    private void SelectedFloorplanOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
    {
        this.ShowStatusChangeCommand.RaiseCanExecuteChanged();
    }
    public ObservableCollection<FloorplanData> SelectedFloorplan
    {
        get
        {
            return _selectedFloorplan;
        }
        set
        {
            _selectedFloorplan = value;
            this.ShowStatusChangeCommand.RaiseCanExecuteChanged();
        }
    }
