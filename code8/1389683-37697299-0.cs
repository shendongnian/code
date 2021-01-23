    [TestMethod]
            public void Test()
            {
                Logging.Instance.Trace("TRACE 1");
                Logging.Instance.Debug("DEBUG 1");
                Logging.Instance.Warn("WARN 1");
    
                foreach (LoggingRule rule in LogManager.Configuration.LoggingRules)
                {
                    rule.DisableLoggingForLevel(LogLevel.Trace);
                    rule.DisableLoggingForLevel(LogLevel.Debug);
                }
                LogManager.ReconfigExistingLoggers();
    
                Logging.Instance.Trace("TRACE 2");
                Logging.Instance.Debug("DEBUG 2");
                Logging.Instance.Warn("WARN 2");
    
                // Reconfigure();
                LogManager.Configuration = LogManager.Configuration.Reload();
                LogManager.ReconfigExistingLoggers();
    
                Logging.Instance.Trace("TRACE 3");
                Logging.Instance.Debug("DEBUG 3");
                Logging.Instance.Warn("WARN 3");
            }
