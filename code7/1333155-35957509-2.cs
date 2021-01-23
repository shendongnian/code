    public string LastName
    {
        get { return _lastName; }
        set { 
            if(value.Contains("!")){
                throw new Exception("names can't contain '!'");
            }
            _lastName = value; }
    }
