    public interface ILoginService
    {
        bool SomeAction(string parameter);
        string Password  {set; }
        string UserName {set; }
    }
    
    public class LoginService : ILoginService
    {
        private string _connectionString;
    
        public LoginService(string connectionStringPart)
        {
            _connectionString = connectionStringPart;
        }
        
        public string Password
        {
            set { _connectionString.Concat(value); }
        }
        public string UserName
        {
            set { _connectionString.Concat(value); }
        }
        public bool SomeAction(string parameter)
        {
            //Create connection, execute query etc.
            return true;
        }
    }
    
    public class MainViewModel : ViewModelBase
    {
        private ILoginService _loginService;
        private string _login;
    
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                _loginService.UserName = value; 
                RaisePropertyChanged("Login");
            }
        }
    
        private string _password;
    
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                _loginService.Password= value; 
                RaisePropertyChanged("Password");
            }
        }
        public MainViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
    
        private RelayCommand _loginCommand;
    
        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(ExecuteLogin)); }
        }
    
        private void ExecuteLogin()
        {
            
            _loginService.SomeAction("some parameter");
        }
