    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH-mm-ss}"] 
    public DateTime MyDateTime
    {
       get
       {
           // should be defined as a constant elsewhere
           string pattern = "yyyyMMddHHmmss";
           DateTime dt;
           if (DateTime.TryParseExact(text, pattern, CultureInfo.InvariantCulture, 
                               DateTimeStyles.None, out dt))
              return dt;
    
           // return a value when format is invalid
       }
    }
