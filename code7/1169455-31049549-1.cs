    public static class Log
    {
        private static Config _config = LoadConfig();
    
        public static void Info(string val1, string val2)
        {
              NLog.Logger logger = NLog.LogManager.GetLogger("_dataBase");
    
              GlobalDiagnosticsContext.Set("myConnectionString", _config.ConnectString);
              GlobalDiagnosticsContext.Set("myDataBase", _config.DBName);
    
              LogEventInfo info = new LogEventInfo(LogLevel.Info, "_dataBase", "Test_message");
              info.Properties["val1"] = val1;
              info.Properties["val2"] = val2;
    
              logger.Log(info);
        }
    }
