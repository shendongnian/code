    public class MainWindowViewModel 
    {
        public MainWindowViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }
        public DelegateCommand LoginCommand { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        private void Login()
        {
            if (Username == "user" && Password == "user")
            {
                
            }
        }
    }
