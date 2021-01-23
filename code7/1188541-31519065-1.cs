    string input = "$1000.00";
    decimal decimalValue;
    if(decimal.TryParse(input, out decimalValue))
    {
        // using current CurrencySymbol, same as Convert.ToDecimal
        Console.WriteLine("Converted successfully: " + decimalValue);
    }
    else
    {
        var usCulture = new CultureInfo("en-US");
        if (decimal.TryParse(input, NumberStyles.Currency, usCulture, out decimalValue))
        {
            // using dollar sign as CurrencySymbol
            Console.WriteLine("Converted successfully with CultureInfo(en-US): " + decimalValue);
        }
        else
        {
            Console.WriteLine("Could not be parsed to decimal");
        }
    }
