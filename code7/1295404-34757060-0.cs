     public class ServerDataSource : IDataSource
        {
            private Logger _log;
            public ServerDataSource()
            {
                _log = LogManager.GetLogger("ServerDataSource");
            }
          public bool DoSomething()
            {
                try
                {
                      _log.Info("Doing something");
    
                }
                catch (Exception ex)
                {
                    _log.Error("Error occurred" + ex.Message);
                }
            }
    }
    
