    public string ToString(string format, IFormatProvider provider)
    {
    	return Currency + " " + RawAmount.ToString(format, provider);
    }
    public string ToString(string format)
    {
        return ToString(format, NumberFormatInfo.CurrentInfo);
    }
    public string ToString(IFormatProvider provider)
    {
        return ToString("0.00", provider);
    }
    public override string ToString()
    {
        return ToString(provider);
    }
