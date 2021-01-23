    class HistoryViewModel : INotifyPropertyChanged
    {
        private Uri _pictureUri;
        public Uri PictureUri
        {
            get
            {
                return _pictureUri;
            }
            set
            {
                if (value == _pictureUri)
                    return;
                _pictureUri = value;
                RaisePropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
