    public static bool validTelephoneNo(string telNo)
    {
        PhoneNumber number;
        try
        {
            number = PhoneNumberUtil.Instance.Parse(telNo, "US");
        }
        catch (NumberParseException e)
        {
            return false;
        }
        
        return number.IsValidNumber;
    }
