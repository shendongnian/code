      public class LoginViewModel : ViewModelBase
    {
        private static ILog Logger = LogManager.GetLogger(typeof(LoginViewModel));
        #region Properties
        private String _title;
        private String _login;
        private String _password;
        private String _validationMessage;
        private bool _displayLoginButton;
        private bool _displayLoginProgressRing;
        private bool _enableInput;
        private bool _displayValidationMessage;
     
        private ICommand _loginCommand;
        public LoginViewModel()
        {
            DisplayLoginButton = EnableInput = true;
            DisplayLoginProgressRing = DisplayValidationMessage = false;
        }
        public bool DisplayValidationMessage
        {
            get { return _displayValidationMessage; }
            set
            {
                _displayValidationMessage = value;
                RaisePropertyChanged(() => this.DisplayValidationMessage);
            }
        }
        public bool DisplayLoginButton
        {
            get { return _displayLoginButton; }
            set
            {
                _displayLoginButton = value;
                RaisePropertyChanged(() => this.DisplayLoginButton);
            }
        }
        public bool EnableInput
        {
            get { return _enableInput; }
            set
            {
                _enableInput = value;
                RaisePropertyChanged(() => this.EnableInput);
            }
        }
        public bool DisplayLoginProgressRing
        {
            get { return _displayLoginProgressRing; }
            set
            {
                _displayLoginProgressRing = value;
                RaisePropertyChanged(() => this.DisplayLoginProgressRing);
            }
        }
        public String Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged(() => this.Title);
            }
        }
        public String Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                RaisePropertyChanged(() => this.Login);
            }
        }
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged(() => this.Password);
            }
        }
        public String ValidationMessage
        {
            get
            {
                return _validationMessage;
            }
            set
            {
                _validationMessage = value;
                RaisePropertyChanged(() => this.ValidationMessage);
            }
        } 
        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand =
                    new RelayCommand<object>((param) => ExecuteLoginCommand(param), (param) => CanExecuteLoginCommand(param)));
            }
        }
        private bool CanExecuteLoginCommand(object parameter)
        {
            var paramArray = (object[])parameter;
            if (paramArray == null) return false;
            PasswordBox pb = paramArray[0] as PasswordBox;
            if (pb == null) return false;
            var pwdText = pb.Password;
            return !(String.IsNullOrEmpty(pwdText) && Login != null);
        }
        private void ExecuteLoginCommand(object parameter)
        {
            Logger.InfoFormat("User [{0}] attempting to login", this.Login);
            
            DisplayLoginButton = false;
            DisplayLoginProgressRing = true;
            EnableInput = false;
            var paramArray = (object[])parameter;
            var pb = paramArray[0] as PasswordBox;
            var loginWindow = paramArray[1] as LoginView;
            if (pb != null)
                Password = pb.Password;
            if (ValidateInput())
            {
                if (SynchronizationContext.Current == null)
                    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());
                var curSyncContext = SynchronizationContext.Current;
                bool authenticated = false;
                Task.Factory.StartNew(() =>
                {
                    authenticated = CredentialService.Instance.Store(int.Parse(Login), Password);
                    Thread.Sleep(1000);
                }).ContinueWith((task) =>
                {
                    curSyncContext.Send((param) =>
                    {
                        if (authenticated)
                        {
                            Logger.InfoFormat("User [{0}] Authenticated Successfully, Logging In", this.Login);
                            var mainWindow = new MainWindow();
                            mainWindow.Show();
                            loginWindow.Close();
                        }
                        else
                        {
                            Logger.InfoFormat("User [{0}] Failed to Authenticate", this.Login);                            
                            DisplayValidationMessage = true;
                            ValidationMessage = INVALID_CREDENTIALS;
                            DisplayLoginButton = true;
                            DisplayLoginProgressRing = false;
                            EnableInput = true;
                        }
                    }, null);
                });
            }
            else
            {
                Logger.InfoFormat("User [{0}] failed input validation", this.Login);
                DisplayValidationMessage = true;
                ValidationMessage = INVALID_INPUT;
                DisplayLoginButton = true;
                DisplayLoginProgressRing = false;
                EnableInput = true;
            }
        } 
        #endregion
