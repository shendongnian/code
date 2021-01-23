    private Visibility isloading = Visibilty.Collapsed(orHidden);
        public Visibility Isloading
        {
        get{return isloading;}
        set{isloading = value;
        OnPropertyChanged("Isloading");
        }
