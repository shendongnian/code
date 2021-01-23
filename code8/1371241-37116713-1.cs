    public static CheckInput ValidateInput(string firstName, string lastName, string password)
    {
        CheckInput result = CheckInput.OK;
        if (string.IsNullOrWhiteSpace(firstName))
            result |= CheckInput.No_First_Name;
        if (string.IsNullOrWhiteSpace(lastName))
            result |= CheckInput.No_Last_Name;
        if (string.IsNullOrEmpty(password))
            result |= CheckInput.No_Password;
        else if (!PasswordIsValid(password))
            result |= CheckInput.Wrong_Password;
        return result;
    }
