    response.Headers.CacheControl = new CacheControlHeaderValue()
    {
          Public = false,
          MaxAge = new TimeSpan(0, 0, 900)
    };  
