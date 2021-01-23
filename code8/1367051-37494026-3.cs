    public static char ToChar(int value)
    {
        if ((value < 0) || (value > 0xffff))
        {
            throw new OverflowException(Environment.GetResourceString("Overflow_Char"));
        }
        return (char) value;
    }
