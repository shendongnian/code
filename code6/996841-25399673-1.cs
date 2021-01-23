    string str = "20140820";
    string[] format = {"yyyyMMdd"};
    DateTime date;
    DateTime.TryParseExact(str, 
                              format, 
                              System.Globalization.CultureInfo.InvariantCulture,
                              System.Globalization.DateTimeStyles.None, 
                              out date))
