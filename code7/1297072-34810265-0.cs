        private ObservableCollection<ImageGalleryFilename> _imageGalleryFilenames;
        public ObservableCollection<ImageGalleryFilename> ImageGalleryFilenames
        {
            get
            {
                return _imageGalleryFilenames;
            }
            set
            {
                _imageGalleryFilenames= value;
                if (_imageGalleryFilenames!= null)
                {
                    _imageGalleryFilenames.CollectionChanged += _imageGalleryFilenames_CollectionChanged;
                }
                NotifyPropertyChanged("ImageGalleryFilenames");
            }
        }
        private void _imageGalleryFilenames_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("ImageGalleryFilenames");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
