    BitmapImage _imageViewerSource;
    
    public BitmapImage ImageViewerSource {
        get { return _imageViewerSource; }
        private set
        { 
            _imageViewerSource = value;
            OnPropertyChanged("ImageViewerSource"); // or OnPropertyChanged(nameof(ImageViewerSource)); if you are using VS2015+
        }
    }
