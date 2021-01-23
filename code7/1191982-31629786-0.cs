    using System;
    using System.Windows.Input;
    class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private UserModel user;
        private DelegateCommand _loginCommand;
        public UserModel User
        {
            get { return user; }
            set { user = value; }
        }
    
        public string UserName
        {
            get { return user.UserName; }
            set
            {
                user.UserName = value;
                OnPropertyChanged("UserName");
            }
        }
    
        public ICommand LoginCommand
        {
            get { return _loginCommand; }
        }
    
        public LoginViewModel()
        {
            _loginCommand = new DelegateCommand(OnLogin, CanOnLogin);
            //implement CanOnLoginChanged here?
            user = new UserModel();
        }
    
        private bool CanOnLogin(object parameter)
        {
            if (String.IsNullOrEmpty(user.UserName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public event EventHandler CanOnLoginChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        private void OnLogin(object parameter)
        {
            // Do something here
            MessageBox.Show(user.UserName);
        }
    
        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    
       
    }
