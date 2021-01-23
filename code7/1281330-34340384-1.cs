        public class MainWindowViewModel : ViewModelBase
        {
            ViewModelBase _activeView;
    
            public MainWindowViewModel()
            {
                _activeView = new EnterPasswordViewModel();
                ChangeViewCommand = new ChangeViewCommand(this);
            }
    
            public ViewModelBase ActiveView
            {
                get { return _activeView; }
    
                set
                {
                    _activeView = value;
                    OnPropertyChanged("ActiveView");
                }
            }
    
            public ICommand ChangeViewCommand { get; set; }
        }
