    public string Output
    {
        get { return output; }
        set
        {
            if (!String.IsNullOrEmpty(value))
            {
                output += value;
            }
        }
    }
