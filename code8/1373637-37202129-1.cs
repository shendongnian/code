    public static string ToGCodeNumber(double number, int digits)
    {
        // rounding (optional)
        double number = Math.Round(number, digits);
        // result with or without '.'
        string intermediateResult = roundedNumber .ToString(CultureInfo.InvariantCulture);
        if(!intermediateResult .Contains(".")
            intermediateResult += ".";
        // final result with a guaranteed '.'  
        return intermediateResult;
    }
