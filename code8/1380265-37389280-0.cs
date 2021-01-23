    var ca = new RegionInfo("en-CA");
    var cai = new CultureInfo("en-CA")
    {
        NumberFormat =
        {
            CurrencySymbol = ca.ISOCurrencySymbol,
            CurrencyPositivePattern = 2
        }
    };
    Console.WriteLine(test.ToString("C", cai));
