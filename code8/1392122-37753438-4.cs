    public static string GenerateChecks(List<CheckJob> checkJobs, bool throwOnError = true)
    {
        //...
        catch (Exception ex)
        {
          if(throwOnError)
          {
            if (Transaction.IsInTransaction)
            {
               Transaction.Rollback();
            }
            throw;
          }
        }
    }
