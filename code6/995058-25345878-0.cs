    public static int ToInt32(this char c)
    {
        if (!Char.IsNumber(c))
        {
            throw new ArgumentException("Char is not a number", "c");
        }
        return c - '0';
    }
