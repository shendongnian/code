    public string ProductNo
    { 
        get { return _productNo}
        set
        {
            if (_productNo != value)
            {
                _productNo = value;
                RaisePropertyChanged();
                RaisePropertyChanged(() => ThumbnailImageUri);
            }
        }
    }
    public Uri ThumbnailImageUri
    {
        get
        {
            if (_thumbnailImageUri == null)
            {
                _thumbnailImageUri = new Uri(String.Format("http://www.YOURWEBSITE.com/{0}.jpg", _productNo));
            }
            return _thumbnailImageUri;
        }            
    }
