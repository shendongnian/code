            private void Load(object o)
        {
            var name = _mFileProvider.GetFileName();
            if(string.IsNullOrEmpty(name)) return;
            ImageSourceBmp = null;
            ZoomOriginal();
            ImageSourceBmp = new BitmapImage(new Uri(name));
        }
        public BitmapImage ImageSourceBmp   
        {
            get { return _imageSourceBmp; }
            set
            {
                _imageSourceBmp = value;
                OnPropertyChanged();
            }
        }
