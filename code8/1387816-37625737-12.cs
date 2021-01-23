    public class MainWindowViewModel : ObservableObject
    {
        LoginViewModel loginViewModel = new LoginViewModel();
        LoggedInViewModel loggedInViewModel = new LoggedInViewModel();
        public MainWindowViewModel()
        {
            CurrentWorkspace = loginViewModel;
            LoginCommand = new RelayCommand((p) => DoLogin());
        }
        private WorkspaceViewModel currentWorkspace;
        public WorkspaceViewModel CurrentWorkspace
        {
            get { return currentWorkspace; }
            set
            {
                if (currentWorkspace != value)
                {
                    currentWorkspace = value;
                    OnPropertyChanged();
                }
            }
        }
        public ICommand LoginCommand { get; set; }
        public void DoLogin()
        {
            bool isValidated = loginViewModel.Validate();
            if (isValidated)
            {
                CurrentWorkspace = loggedInViewModel;
            }
        }
    }
