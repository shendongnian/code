    public static char ChrW(int CharCode)
    {
        if ((CharCode < -32768) || (CharCode > 0xffff))
        {
            throw new ArgumentException(Utils.GetResourceString("Argument_RangeTwoBytes1", new string[] { "CharCode" }));
        }
        return Convert.ToChar((int) (CharCode & 0xffff));
    }
