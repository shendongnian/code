    public string this[string columnName]
    {
        get
        {
            if(columnName == "SomeRandomText")
            {
                if(string.IsNullOrEmpty(SomeRandomText) || SomeRandomText.Length < 4)
                {
                    return "Text should be at least four characters long";
                }
            }
    
            return null;
        }
    }
