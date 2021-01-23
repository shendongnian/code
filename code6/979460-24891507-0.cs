    private string _LastName;
    public string LastName 
    {
        get
        {
            if (String.IsNullOrEmpty(_LastName) || String.IsNullOrWhiteSpace(_LastName))
            {
                return "Empty"; // or whatever
            }
            else
            {
                return _LastName;
            }
    
        }
        set
        {
            if (String.IsNullOrEmpty(_LastName) || String.IsNullOrWhiteSpace(_LastName))
            {
                _LastName = value;
            }
            // else do not set
        }
