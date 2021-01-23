    [TestMethod]
            public void Test()
            {
                Logger.Trace("TRACE 1");
                Logger.Debug("DEBUG 1");
                Logger.Warn("WARN 1");
    
                foreach (LoggingRule rule in LogManager.Configuration.LoggingRules)
                {
                    rule.DisableLoggingForLevel(LogLevel.Trace);
                    rule.DisableLoggingForLevel(LogLevel.Debug);
                }
                LogManager.ReconfigExistingLoggers();
    
                Logger.Trace("TRACE 2");
                Logger.Debug("DEBUG 2");
                Logger.Warn("WARN 2");
    
                // Reconfigure();
                LogManager.Configuration = LogManager.Configuration.Reload();
                LogManager.ReconfigExistingLoggers();
    
                Logger.Trace("TRACE 3");
                Logger.Debug("DEBUG 3");
                Logger.Warn("WARN 3");
            }
