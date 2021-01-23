    public class LoginViewModel : WorkspaceViewModel
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                if (userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Validate()
        {
            if (UserName == "bob")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
