    public class LoginViewLogic : INotifyPropertyChanged
    {
        public LoginViewLogic() 
        {
           _userData = new User(AppSettings.ReadCredentials(),(bool)loadedSettings); 
        }
        private User _userData;
        public User UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
