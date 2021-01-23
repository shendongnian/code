    private bool hasErrors;
    
    public string this[string fieldName]
    {
        get
        {
            if (string.IsNullOrEmpty(Name))
            {                
                hasErrors = true;
                return "Name is required!";
            }
            else
            {
                hasErrors = false;
                return null;
            }
        }
    }
