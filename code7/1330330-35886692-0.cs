    public string FirstName 
    {
        get { return firstName; }
        set
        {
            if(string.IsNullOrEmpty(value)) 
            {
                 // where errors is a Dictionary<string, string>
                 errors.Add(nameof(FirstName), "First name can't be empty.");
                 return;
            }
            if(value.Length <2) 
            {
                 errors.Add(nameof(FirstName), "First name must be at least 2 characters long.");
                 return
            }
            Set(ref firstName, value);
            errors.Remove(nameof(FirstName));
        }
    }
