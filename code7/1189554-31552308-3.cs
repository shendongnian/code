    public static class FormatProviderExtensions
    {
        public static IFormatProvider GetCustomFormatter(this NumberFormatInfo info, decimal d)
        {
            var truncated = Decimal.Truncate(d);
            if (truncated == d)
            {
                return new NumberFormatInfo
                {
                    NumberDecimalDigits = 0,
                    NumberDecimalSeparator = info.NumberDecimalSeparator,
                    NumberGroupSeparator = info.NumberGroupSeparator
                };
            }
            // The 4th element contains the exponent of 10 used by decimal's 
            // representation - for more information see
            // https://msdn.microsoft.com/en-us/library/system.decimal.getbits.aspx
            var fractionalDigitsCount = BitConverter.GetBytes(Decimal.GetBits(d)[3])[2];
            return fractionalDigitsCount <= 2
                ? new NumberFormatInfo
                {
                    NumberDecimalDigits = 2,
                    NumberDecimalSeparator = info.NumberDecimalSeparator,
                    NumberGroupSeparator = info.NumberGroupSeparator
                }
                : new NumberFormatInfo
                {
                    NumberDecimalDigits = fractionalDigitsCount,
                    NumberDecimalSeparator = info.NumberDecimalSeparator,
                    NumberGroupSeparator = info.NumberGroupSeparator
            };
        }
    }
