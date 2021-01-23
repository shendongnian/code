    private DateTime? date;
    public DateTime? Date
    {
         get
         {
              if(date != null)
                   return TimeZoneInfo.ConvertToUtc(date);
    
              return date;           
         }
    }
