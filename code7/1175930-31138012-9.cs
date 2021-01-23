    public class ItemVM : INotifyPropertyChanged
    {
        //implementation of INotifyPropertyChanged ...
        string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }
        // Other Properties ...
    }
