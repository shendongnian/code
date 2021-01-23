        public static decimal AsDecimal(this string value)
    {
        decimal result;
        return decimal.TryParse(value, out result) ? result : 0;
    }
    public static decimal? AsNullableDecimal(this string value)
    {
        decimal result;
        bool IsValid = decimal.TryParse(value, out result);
        if (IsValid)
        {
            return result;
        }
        else
        {
            return null;
        }
    }
