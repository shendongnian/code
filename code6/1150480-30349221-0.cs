    int decimalPlaces = 10;
    decimal number = 123456789.1234567890M;
    string[] parts = number.ToString("F" + decimalPlaces).Split(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]);
    long[] lParts = new long[parts.Length];
    for (int i = 0; i < parts.Length; i++)
        lParts[i] = Convert.ToInt64(parts[i]);
    for (int i = 0; i < parts.Length; i++)
        Console.WriteLine(lParts[i].ToString());
