    private string GetSuffix(DateTime dt)
    {
       if(dt.Days % 10 == 1)
       {
          return dt.Days.ToString() + "st";
       }
       else if(dt.Days % 10 == 2)
       {
          return dt.Days.ToString() + "nd";
       }
       else if(dt.Days % 10 == 3)
       {
          return dt.Days.ToString() + "rd";
       }
       else
       {
          return dt.Days.ToString() + "th";
       } 
    }
