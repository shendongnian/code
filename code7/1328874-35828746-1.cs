     private string DateTimeSQLite(DateTime datetime)
      {
        string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
        return string.Format(dateTimeFormat, datetime.Year,   
                             datetime.Month,datetime.Day, 
                             datetime.Hour, datetime.Minute,  
                              datetime.Second,datetime.Millisecond);
      }
