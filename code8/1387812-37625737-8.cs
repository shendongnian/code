    public class LoggedInViewModel : WorkspaceViewModel
    {
        private string restrictedData = "Some restricted data";
        public string RestrictedData
        {
            get { return restrictedData; }
            set
            {
                if (restrictedData != value)
                {
                    restrictedData = value;
                    OnPropertyChanged();
                }
            }
        }
    }
