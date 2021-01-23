    public string NameCheck
    {
        get {
            return name;
        }
        set
        {
            // You need to check value, not name.
            if (string.IsNullOrEmpty(value))
            {
                name = "Name not specified";
            }
            else 
            {
                name = value;
            }
        }
    }
