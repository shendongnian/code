    protected override bool ShouldRetryOn(Exception exception)
    {
      bool shouldRetry = false;
     
      SqlException sqlException = exception as SqlException;
      if (sqlException != null)
      {
        foreach (SqlError error in sqlException.Errors)
        {
          if (error.Number == -2)
            shouldRetry = true;
        }
      }
     
      shouldRetry = shouldRetry || base.ShouldRetryOn(exception);
     
      Logger.WriteLog("ShouldRetryOn: " + shouldRetry);
      return shouldRetry;
    }
