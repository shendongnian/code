    public class LoggingDataAccess
    {
      private readonly string _connectionString;
      public LoggingDataAccess(IConnectionSettings settings)
      {
        _connectionString = settings.Logging.ConnectionString;
      }
      public void SomeRawAdo()
      {
        using (var con = new Connection(_connnectionstring))
        {
        }
      }
    }
