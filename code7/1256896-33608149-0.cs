    public EDentalCADBContext(string con = null)
        : base(string.IsNullOrEmpty(con) ? "name=EDentalCADBContext" : con)
    {
    
    }
    
