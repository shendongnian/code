    XmlConfigurator.Configure();
    if (isLinux){
            var repository = LogManager.GetRepository() as Hierarchy;
            if (repository != null)
            {
                var appenders = repository.GetAppenders();
                if (appenders != null)
                {
                    foreach (var appender in appenders)
                    {
                        if (appender is FileAppender)
                        {
                            var fileLogAppender = appender as FileAppender;
                            fileLogAppender.File = fileLogAppender.File.Replace("\","//");
                        }
                    }
                }
            }
    }
       
