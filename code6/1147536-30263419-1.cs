    public Money Round(int decimals, MidpointRounding mode)
    {
        return new Money(Currency, Amount.Round(decimals, mode));
    }
    public Money Round(MidpointRounding mode)
    {
        return Round(2, mode);
    }
    public Money Round(int decimals)
    {
        return Round(decimals, MidpointRounding.ToEven);
    }
    public Money Round()
    {
        return Round(2);
    }
