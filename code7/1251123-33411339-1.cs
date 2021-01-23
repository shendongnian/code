    public int Port
    {
        get { return _port; }
        set { SetProperty(ref _port, string.IsNullOrWhitespace(value.ToString())?0 :value); 
    }
    
