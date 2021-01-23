    catch (AggregateException ex) when (ex.InnerException is DocumentClientException)
    {
        DocumentClientException dce = (DocumentClientException)ex.InnerException;
        switch ((int)dce.StatusCode)
        {
            case 429:
                Thread.Sleep(dce.RetryAfter);
                break;
             default:
                 Console.WriteLine("  Failed: {0}", ex.InnerException.Message);
                 throw;
         }                    
    }
