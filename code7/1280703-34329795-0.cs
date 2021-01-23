    private ImageSource mainImage;
    public ImageSource MainImage
    {
        get { return mainImage; }
        set
        {
            if (mainImage != value)
            {
                mainImage = value;
                OnPropertyChanged("MainImage");
            }                                        
        }
    }
