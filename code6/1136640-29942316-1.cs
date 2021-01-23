    public static bool validTelephoneNo(string telNo)
    {
        PhoneNumber number;
        try
        {
            number = PhoneNumberUtil.Instance.Parse(telNo, "US");  // Change to your default language, international numbers will still be recognised.
        }
        catch (NumberParseException e)
        {
            return false;
        }
        
        return number.IsValidNumber;
    }
