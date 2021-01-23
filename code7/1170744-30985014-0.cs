    decimal amount = 1234.56m;
    CultureInfo us = new CultureInfo("en-US");
    CultureInfo gb = new CultureInfo("en-GB");
    CultureInfo by = new CultureInfo("be-BY");
    NumberFormatInfo nf1 = us.NumberFormat;
    NumberFormatInfo nf2 = gb.NumberFormat;
    NumberFormatInfo nf3 = by.NumberFormat;
    string s1 = amount.ToString("c", nf1);
    string s2 = amount.ToString("c", nf2);
    string s3 = amount.ToString("c", nf3);
    Console.WriteLine(s1);    // $1,234.56
    Console.WriteLine(s2);    // £1,234.56
    Console.WriteLine(s3);    // 1 234,56 Br
    decimal d1 = Decimal.Parse(s1, NumberStyles.Currency, us);
    decimal d2 = Decimal.Parse(s2, NumberStyles.Currency, gb);
    decimal d3 = Decimal.Parse(s3, NumberStyles.Currency, by);
    Console.WriteLine(d1);    // 1234.56
    Console.WriteLine(d2);    // 1234.56
    Console.WriteLine(d3);    // 1234.56
