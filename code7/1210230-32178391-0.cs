    public static Boolean TryParseExtended(String value, out DateTime result) {
      result = DateTime.MinValue;
      String[] formatsToTry = new String[] {
        "MM/dd/yyyy",
        "MM/dd/yyyy hh:mm:ss",
        "dd.MM.yyyy",
        "dd.MM.yyyy hh:mm:ss",
        "yyyy-MM-dd",
        "yyyy-MM-dd hh:mm:ss",
      };
      foreach (var format in formatsToTry)
        if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result)
          return true;
      return false;
    }
...
      foreach (string date in DateString) {
        Console.WriteLine(date);
        DateTime DtTemp = new DateTime();
    
        if (TryParseExtended(date, out DtTemp)) {
          ....
        } 
      }
