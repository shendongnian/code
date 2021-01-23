    public MainViewModel()
    {
       LoadedControl = new FirstControlViewModel();
    }
    private ViewModelBase _LoadedControl;
    
    public ViewModelBase LoadedControl
    {
        get { return _LoadedControl; }
        set { _LoadedControl = value;
              NotifyPropertyChanged("LoadedControl");
        }
    }
