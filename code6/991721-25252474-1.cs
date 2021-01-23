    private void UpdateToken()
    {
      
      try 
      {
         if ((DateTime.Now - refreshTime).TotalMinutes >= 60) 
         {
             Token newToken = GetNewToken();
             _latestToken = newToken.AccessToken;
              refreshTime = DateTime.Now;
         }
      }
      finally
      {
        _readWriteLockSlim.ExitWriteLock();
      }
    }
