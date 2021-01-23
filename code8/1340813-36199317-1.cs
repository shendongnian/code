    public static class stringExtension
    {
        public static decimal ToDecimal(this string s, int precision, int scale)
        {
            if (s.Length < precision)
                throw new ArgumentException();
            return decimal
                .Parse(
                s.Substring(s.Length - precision)
                .Insert(precision - scale, ".")
                .ToString()
                ,
                System.Globalization.NumberStyles.AllowDecimalPoint,
                System.Globalization.NumberFormatInfo.InvariantInfo
                );
        }
    }
