    using System.Globalization;
    public static string customConvert(double num)
    {
        NumberFormatInfo customFormat = new NumberFormatInfo();
        customFormat.NumberDecimalSeparator = "__2E__";
        customFormat.NegativeSign = "__2D__";
        return num.ToString(customFormat);
    }
