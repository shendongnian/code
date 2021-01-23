    public class UserInfo : INotifyPropertyChanged, IDataErrorInfo
    {
        private static Regex emailRegex = new Regex(@"^\w+(?:\.\w+)*?@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$");
        private string firstname;
        private string email;
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }
        public string EMail
        {
            get { return email; }
            set { email = value; OnPropertyChanged(); }
        }
        public string Error
        {
            get { return null; }
        }
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "FirstName":
                        return string.IsNullOrWhiteSpace(FirstName) ? "Firstname is required!" : null;
                    case "EMail":
                        return EMail == null || !emailRegex.IsMatch(EMail) ? "The Email Address is not valid!" : null;
                    default:
                        return null;
                }
            }
        }
        public LoginCommand LoginCommand { get; private set; }
        public UserInfo()
        {
            LoginCommand = new LoginCommand(this);
        }
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
