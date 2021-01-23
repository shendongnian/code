    try
    {
      // Some DB access
    }
    catch (Exception ex)
    {
      HandleException(ex);
    }
    
    public virtual void HandleException(Exception exception)
    {
      if (exception is DbUpdateConcurrencyException concurrencyEx)
      {
        // A custom exception of yours for concurrency issues
        throw new ConcurrencyException();
      }
      else if (exception is DbUpdateException dbUpdateEx)
      {
        if (dbUpdateEx.InnerException != null
                && dbUpdateEx.InnerException.InnerException != null)
        {
          if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
          {
            switch (sqlException.Number)
            {
              case 2627:  // Unique constraint error
              case 547:   // Constraint check violation
              case 2601:  // Duplicated key row error
                          // Constraint violation exception
                // A custom exception of yours for concurrency issues
                throw new ConcurrencyException();
              default:
                // A custom exception of yours for other DB issues
                throw new DatabaseAccessException(
                  dbUpdateEx.Message, dbUpdateEx.InnerException);
            }
          }
          throw new DatabaseAccessException(dbUpdateEx.Message, dbUpdateEx.InnerException);
        }
      }
      // If we're here then no exception has been thrown
      // So add another piece of code below for other exceptions not yet handled...
    }
