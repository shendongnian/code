    string curC = System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
    System.Globalization.NumberFormatInfo curFormat = new System.Globalization.CultureInfo(curC).NumberFormat;
    curFormat.CurrencyNegativePattern = 1;
    num.ToString("c", curFormat);
    // or string.Format(curFormat, "{0:c}", num);
