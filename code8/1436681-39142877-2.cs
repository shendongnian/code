    // Create a new file appender
    public static log4net.Appender.IAppender CreateFileAppender(string name,
    string fileName)
    {
        log4net.Appender.FileAppender appender = new
        log4net.Appender.FileAppender();
        appender.Name = name;
        appender.File = fileName;
        appender.AppendToFile = true;
      
        log4net.Layout.PatternLayout layout = new
        log4net.Layout.PatternLayout();
        layout.ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n";
        layout.ActivateOptions();
    
        appender.Layout = layout;
        appender.ActivateOptions();
    
        return appender;
    }
