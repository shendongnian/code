    public class MainViewModel : INotifyPropertyChanged
    {
        private Visibility _imageVisibility;
        public Visibility ImageVisibility
        {
            get { return _imageVisibility; }
            set { _imageVisibility = value; OnPropertyChanged("ImageVisibility"); }
        }
        private BitmapImage _imageSource;
        public BitmapImage ImageSource{...}
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler eventHandler = PropertyChanged;
            if (eventHandler != null)
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
