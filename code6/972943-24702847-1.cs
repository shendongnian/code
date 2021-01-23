    // ViewBaseModel is a basic implementation of ViewModel and INotifyPropertyChanged interface 
    // and which implements OnPropertyChanged method to notify the UI that a property changed
    public class LoginViewModel : ViewModelBase<LoginViewModel> {
        private IAuthService authService;
        public LoginViewModel(IAuthService authService) {
            // Inject authService or your Context, whatever you use with the IoC 
            // framework of your choice, i.e. Unity
            this.authService = authService 
        }
        private AsyncRelayCommand loginCommand;
        public ICommand LoginCommand {
            get {
                return loginCommand ?? (loginCommand = new AsyncCommand(Login));
            }
        }
        private string username;
        public string Username {
            get { return this.username; }
            set {
                if(username != value) {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }
        private string password;
        public string Password {
            get { return this.password; }
            set {
                if(password != value) {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }
        private async Task Search() {
            return await Task.Run( () => {
                    // validate the credentials
                    PanelMainMessage = "username und passwort werden überprüft";
                    // for ViewModel properties you don't have to invoke/dispatch anything 
                    // Only if you interact with i.e. Observable Collections, you have to 
                    // run them on the main thread
                    _isValid = pc.ValidateCredentials(this.Username, this.Password);
                    PanelMainMessage = "gruppe wird überprüft";
                    _isSupportUser = isSupport(Username, pc);
                }                
            } );
        }
    }
