    public class ErrorContainer: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        string _message;
        public string Message
        {
            get
            {return _message;}
            set
            {_message = value; OnPropertyChanged("Message");}
        }
    }
