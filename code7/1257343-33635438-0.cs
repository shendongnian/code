     protected override void Write(AsyncLogEventInfo[] logEvents)
     {
        var buckets = SortHelpers.BucketSort(logEvents, c => this.BuildConnectionString(c.LogEvent));
    
        try
        {
            foreach (var kvp in buckets)
            {
                foreach (AsyncLogEventInfo ev in kvp.Value)
                {
                    try
                    {
                        this.WriteEventToDatabase(ev.LogEvent);
                        ev.Continuation(null);
                    }
                    catch (Exception exception)
                    {
                        if (exception.MustBeRethrown())
                        {
                            throw;
                        }
    
                        // in case of exception, close the connection and report it
                        InternalLogger.Error("Error when writing to database {0}", exception);
                        this.CloseConnection();
                        ev.Continuation(exception);
                    }
                }
            }
        }
        finally
        {
            if (!this.KeepConnection)
            {
                this.CloseConnection();
            }
        }
    }
