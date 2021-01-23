    decimal amount = 1234.56m;
    CultureInfo us = new CultureInfo("en-US");
    CultureInfo gb = new CultureInfo("en-GB");
    CultureInfo by = new CultureInfo("be-BY");
                                                                // Values for...
    CultureInfo custom = (CultureInfo)us.Clone();               // USD      GHS
    custom.NumberFormat.CurrencyDecimalDigits = 2;              // 2        2
    custom.NumberFormat.CurrencyDecimalSeparator = " DECIMAL "; // "."      "."
    custom.NumberFormat.CurrencyGroupSeparator = " GROUP ";     // ","      ","
    custom.NumberFormat.CurrencyGroupSizes = new int[] { 2 };   // { 3 }    { 3 }
    custom.NumberFormat.CurrencyNegativePattern = 0;            // 0        0
    custom.NumberFormat.CurrencyPositivePattern = 0;            // 0        0
    custom.NumberFormat.CurrencySymbol = "SYMBOL ";             // "$"      "₵" or "GH₵" ?
    NumberFormatInfo nf1 = us.NumberFormat;
    NumberFormatInfo nf2 = gb.NumberFormat;
    NumberFormatInfo nf3 = by.NumberFormat;
    NumberFormatInfo nf4 = custom.NumberFormat;
    string s1 = amount.ToString("c", nf1);
    string s2 = amount.ToString("c", nf2);
    string s3 = amount.ToString("c", nf3);
    string s4 = amount.ToString("c", nf4);
    Console.WriteLine(s1);    // $1,234.56
    Console.WriteLine(s2);    // £1,234.56
    Console.WriteLine(s3);    // 1 234,56 Br
    Console.WriteLine(s4);    // SYMBOL 12 GROUP 34 DECIMAL 56
    decimal d1 = Decimal.Parse(s1, NumberStyles.Currency, us);
    decimal d2 = Decimal.Parse(s2, NumberStyles.Currency, gb);
    decimal d3 = Decimal.Parse(s3, NumberStyles.Currency, by);
    decimal d4 = Decimal.Parse(s4, NumberStyles.Currency, custom);
    Console.WriteLine(d1);    // 1234.56
    Console.WriteLine(d2);    // 1234.56
    Console.WriteLine(d3);    // 1234.56
    Console.WriteLine(d4);    // 1234.56
