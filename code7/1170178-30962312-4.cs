    public class Patient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FullName"));
            }
        }
    }
