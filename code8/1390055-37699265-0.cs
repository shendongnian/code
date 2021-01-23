    public static double Round(double d)
    {
        var absoluteValue = Math.Abs(d);
        var integralPart = (long)absoluteValue;
        var decimalPart = absoluteValue - integralPart;
        var sign = Math.Sign(d);
        double roundedNumber;
        if (decimalPart > 0.5)
        {
            roundedNumber = integralPart + 1;
        }
        else if (decimalPart == 0)
        {
            roundedNumber = absoluteValue;
        }
        else
        {
            roundedNumber = integralPart + 0.5;
        }
        return sign * roundedNumber;
    }
