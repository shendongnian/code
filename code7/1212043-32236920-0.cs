    [__DynamicallyInvokable]
    public static decimal Parse(string s)
    {
        return Number.ParseDecimal(s, NumberStyles.Number, NumberFormatInfo.CurrentInfo);
    }
