    private Dictionary<string, string> _validationErrors = new Dictionary<string, string>();
   
    public void Validate(string propertyName)
    {
        string validationResult = null;
        switch(propertyName)
        {
            case "FirstName":
                validationResult = ValidateFirstName();
                break; 
            }
            //etc.
        }
        //Clear dictionary properly here instead (You must also handle when a value becomes valid again)
        _validationResults[propertyName] = validationResult;
        //Note that in order for WPF to catch this update, you may need to raise the PropertyChanged event if you aren't doing so in the constructor (AFTER validating)
    }
