    class RemoteDateTime
    {
      public DateTime Now
      {
        DateTime now;
        try
        {
          now = GetServerNow();
        }
        catch
        {
          now = DateTime.Now;
        }
      }
    }
