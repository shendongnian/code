    public bool EmailValidation(string email, int requiredCount)
    {
        var isValid = false;
        lock(locker)
        {
            if (email != _currentEmail || _currentEmail == null)
            {
                _currentEmail = email;
                _countOfExistingMails = (int)GetDataDataFromDB(email);
            }
            if (requiredCount == 0)
            {
                isValid = _countOfExistingMails != 0; // Rule 1
            }
            else if (requiredCount == 1)
            {
                isValid = _countOfExistingMails <= 1; // Rule 2
            }
        }
        // Rule N...
        return isValid;
    }
