    private string _endTime;
    public TimeSpan endTime 
    {
        get
        {
            return DateTime.ParseExact(
                                      _endTime,
                                      "HH:mm 'AM'",
                                      CultureInfo.InvariantCulture
                                      ).TimeOfDay;
         }            
    }
