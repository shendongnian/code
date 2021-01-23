    // in class Foo
    public void ConvertAllMoney(CurrencyCodes newCurrency)
    {
        foreach (var p in typeof(Foo).GetProperties().Where(prop => prop.PropertyType == typeof(Money)))
        {
            Money m = (Money)p.GetValue(this, null);
            p.SetValue(this, m.ConvertTo(newCurrency), null);
        }
    }
