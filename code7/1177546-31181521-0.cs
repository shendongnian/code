    public DateTime MyDate
    {
        get 
        {
            var date = WebConfigurationManager.AppSettings["My_Date_Key"];
            return date == null ? DateTime.Now : 
                                  DateTime.ParseExact(x, "yyyyMMdd", 
                                                      CultureInfo.InvariantCulture);
        }
    }
