    public static bool ParseDoubleExt(string input, out double doubleVal, StringComparison comparison = StringComparison.CurrentCultureIgnoreCase, NumberFormatInfo nfi = null)
    {
        if (nfi == null)
            nfi = NumberFormatInfo.CurrentInfo;
        doubleVal = double.MinValue;
        double d;
        if (double.TryParse(input, out d))
        {
            doubleVal = d;
            return true;
        }
        else
        {
            bool isPosInf = nfi.PositiveInfinitySymbol.Equals(input, comparison);
            if (isPosInf)
            {
                d = double.PositiveInfinity;
                return true;
            }
            bool isNegInf = nfi.NegativeInfinitySymbol.Equals(input, comparison);
            if (isNegInf)
            {
                d = double.NegativeInfinity;
                return true;
            }
            bool isNAN = nfi.NaNSymbol.Equals(input, comparison);
            if (isNAN)
            {
                d = double.NaN;
                return true;
            }
            // to be extended ...
        }
        return false;
    }
