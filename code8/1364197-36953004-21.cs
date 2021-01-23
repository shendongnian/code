    public class HaveLoginData : ViewModelBase
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                RaisePropertyChanged(() => Login);
            }
        }
    }
