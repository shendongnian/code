    ...
    RollingFileAppender roller = new RollingFileAppender();
    roller.AppendToFile = false;
    roller.File = @"Logs\EventLog.txt";
    roller.Layout = patternLayout;
    roller.MaxSizeRollBackups = 5;
    roller.MaximumFileSize = "1GB";
    roller.RollingStyle = RollingFileAppender.RollingMode.Size;
    roller.StaticLogFileName = true;
    var filter = new log4net.Filter.StringMatchFilter
    {
        StringToMatch = "error",
        AcceptOnMatch = true
    }
    roller.AddFilter(filter);
    var filterDeny = new log4net.Filter.DenyAllFilter();
    roller.AddFilter(filterDeny);
    ...
