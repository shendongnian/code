    public string NameCheck
    {
        get
        {
            return name;
        }
        set
        {
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
