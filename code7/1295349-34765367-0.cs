        private Visibility _DownloadImage;
        public Visibility DownloadImage
        {
            get { return _DownloadImage; }
            set
            {
                if (_DownloadImage != value)
                {
                    _DownloadImage = DownloadImage;
                    OnPropertyChanged("DownloadImage");
                }
            }
        }
