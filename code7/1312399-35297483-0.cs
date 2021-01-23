    public static explicit operator MyType(string s)
    {
       // put logic to convert string value to your type
        return new MyType
        {
            value = s;
        };
    }
