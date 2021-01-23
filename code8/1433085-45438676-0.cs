        private ImageSource _imageSource;
    public ImageSource ImageSource
    {
        get { return _imageSource; }
        set
        {
            _imageSource= value;
            PropertyChanged(this, new PropertyChangedEventArgs("ImageSource"));
        }
    }
