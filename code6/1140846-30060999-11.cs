    public int PrecioGram
    {
        get { return _preciogram; }
        set 
        { 
            _preciogram = value; 
            NotifyPropertyChanged("gramos"); // Incorrect property here
        }
    }
