    private static int ConvertStringValue(string value)
    {
      decimal valDouble;
    
      var comma = (NumberFormatInfo)CultureInfo.InstalledUICulture.NumberFormat.Clone();
      comma.NumberDecimalSeparator = ",";
      comma.NumberGroupSeparator = ".";
    
      var dot = (NumberFormatInfo)CultureInfo.InstalledUICulture.NumberFormat.Clone();
      dot.NumberDecimalSeparator = ".";
      dot.NumberGroupSeparator = ".";
    
      if (decimal.TryParse(value, NumberStyles.Currency, comma, out valDouble))
      {
        return Convert.ToInt32(valDouble * 100); 
      }
      else if (decimal.TryParse(value, NumberStyles.Currency, dot, out valDouble))
      {
        return Convert.ToInt32(valDouble * 100);
      }
      else
      {
        return Convert.ToInt32(value);
      }
    }
