    class TrimCommandInterceptor: IDbCommandInterceptor
    {
      public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> ctx)
      {
        foreach (var p in command.Parameters)
        {
           if (p.Value is string)
             p.Value = ((string) p.Value).Trim();
        }
      }
      // Add all the other interceptor methods
    }
