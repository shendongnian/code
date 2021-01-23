     public ObservableCollection<Image> ImageList
        {
            get
            {
                return _imageList;
            }
            set
            {
    ////THIS CHECK
                if (_imageList == null)
                    return;
                _imageList = value;
                OnPropertyChanged();
            }
        }
