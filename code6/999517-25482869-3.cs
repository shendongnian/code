    public void AddLogTarget(string param)
    {
        if (NLog.LogManager.Configuration.FindTargetByName(param) == null)
        {
            var target = new FileTarget
            {
                Name = param,
                FileName = @"C:\" + param + ".log"
            };
            NLog.LogManager.Configuration.AddTarget(param, target);
            NLog.LogManager.Configuration.LoggingRules.Add(new LoggingRule(param, LogLevel.Debug, target));
        }
    }
