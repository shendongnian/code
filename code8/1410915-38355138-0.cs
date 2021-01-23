    public Image Original
    {
        get { return OriginalImage; }
        set
        {
            this.OriginalImage = value;
            base.RaisePropertyChanged("Original");
        }
    }
