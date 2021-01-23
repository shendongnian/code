    public bool SomeBoolParameter
    {
        get { /* ... */ }
        set
        {
            //...
            OnPropertyChanged("SomeBoolParameter");
            OnPropertyChanged("ImageUrl");
        }
    }
    
    public string ImageUrl
    {
        get
        {
            return SomeBoolParameter ? "..." : "...";
        }
    }
