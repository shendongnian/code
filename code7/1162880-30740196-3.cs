    public class Model : INotifyPropertyChanged
    {
        private Uri _ImagePath;
        public Uri ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                _ImagePath = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ImagePath"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
