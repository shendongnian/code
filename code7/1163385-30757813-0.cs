    public override string this[string propertyName]
    {
        get
        {
            string error = string.Empty;
            if (propertyName == "Name" && Name.IsNullOrEmpty()) error = "You must enter the Name field.";
            else if (propertyName == "Name" && Name.Length > 100) error = "That name is too long.";
            ...
            return error;
        }
    }
