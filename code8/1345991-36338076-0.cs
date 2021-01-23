    public string MyProperty
    {
        get
        {
            return MethodBase.GetCurrentMethod().Name.Substring(4);
        }            
    }
