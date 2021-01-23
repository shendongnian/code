    public class ImageService : INotifyPropertyChanged
    {
        private Uri _uri;
        public Uri Uri
        {
            get { return _uri; }
            set
            {
                _uri = value;
                OnPropertyChanged();
            }
        }
        public ImageService()
        {
            Uri = new Uri("ms-appx///assets/Logo.scale-100.png");                                                
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
