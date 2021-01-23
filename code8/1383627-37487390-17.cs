    public bool EmailValidation(string email, int requiredCount)
    {
        // Reduce number of calls
        if (_countOfExistingMails.HasValue)
        {
            _countOfExistingMails = (int)GetDataDataFromDB(email);
        }
        var isValid = false;
        if (requiredCount == 0)
        {
            isValid = requiredCount != 0; // Rule 1
        }
        else if (requiredCount == 1)
        {
            isValid = requiredCount <= 1; // Rule 2
        }
        // Rule N...
        return isValid;
    }
