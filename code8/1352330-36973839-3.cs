    public class User : BasePropertyChanged
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged("UserName"); }
        }
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; OnPropertyChanged("UserName"); }
        }
    }
