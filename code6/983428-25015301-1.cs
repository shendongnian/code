    private string _formDigest;
    public string FormDigest
    {
        get
        {
           if (_formDigest == null || DateTime.Now > _expires)
           {
               return GetFormDigest();
           }
           return _formDigest;
        }
    }
