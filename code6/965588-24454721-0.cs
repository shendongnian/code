    public override string this[string propertyName]
    {
        get
        {
            string error = string.Empty;
            if ((propertyName == "FirstName" || propertyName == "LastName") && 
                (FirstName == string.Empty || LastName == string.Empty)) 
                error = "You must enter either the First Name or Last Name fields.";
            return error;
        }
    }
