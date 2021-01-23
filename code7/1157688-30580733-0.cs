    private static string ConvertInteger(long Value, byte Base)
    {
        if (Base < 2)
            throw new ArgumentOutOfRangeException("Base", Base, "The NumericStringConverter.Convert(Value, Base) method was called, with the Base parameter set to a value less than 2.");
        if (Base > 64) 
            throw new ArgumentOutOfRangeException("Base", Base, "The NumericStringConverter.Convert(Value, Base) method was called, with the Base parameter set to a value greater than 64.");
        if (Value == 0) 
            return StandardDigits[0];
        string strResult = "";
        bool IsValueNegative = (Value < 0); 
        while (Value != 0) 
        {
            strResult = strResult.Insert(0, StandardDigits[Value % Base]); 
            Value /= Base; 
        }
        if (IsValueNegative)
            strResult = strResult.Insert(0, "-");
        return strResult;
    }
    public static string Convert(int Value, byte Base)
    {
        return ConvertInteger((long)Value, Base);
    }
    public static string Convert(ulong Value, byte Base)
    {
        return ConvertInteger((long)Value, Base); // check for overflow?
    }
