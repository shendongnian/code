       public class MainWindowVM : ViewModelBase
        {
            private RelayCommand _ShowWorkSpace;
            private static MainWindowVM _Instance;
            public static MainWindowVM Instance { get { return _Instance; } }
    
            private string _userControlToShow;
            public string UserControlToShow 
            {
            	get { return _userControlToShow; }
            	set
            	{
            		_userControlToShow = value;
            		RaisePropertyChanged("UserControlToShow");
            	}
            }
    
            public MainWindowVM()
            {
                MainWindowVM._Instance = this;
            }
    
            public RelayCommand ShowWorkSpace
            {
                get
                {
                    if (_ShowWorkSpace == null)
                        _ShowWorkSpace = new RelayCommand(param => { });
                    return _ShowWorkSpace;
                }
            }
        }
