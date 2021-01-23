    // in class Foo
    public void ConvertAllMoney(CurrencyCodes newCurrency)
    {
        foreach (Money m in V)
            m = m.ConvertTo(newCurrency);
    }
