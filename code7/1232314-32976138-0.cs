    private void loadReport1IntoCache()
    {
      //...load your data from DB into the Report1 variable here
      //this line is new, and it saves your data into a global Cache variable
      //with an absolute expiration of 10 minutes
      Cache.Insert("Report1", Report1, null,
      DateTime.Now.AddMinutes(10d), 
      System.Web.Caching.Cache.NoSlidingExpiration);
    
    }
