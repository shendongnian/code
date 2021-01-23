    public static void ChangeFilePath(string appenderName, string newFilename)
            {                       
                log4net.Repository.ILoggerRepository repository = log4net.LogManager.GetRepository();
                foreach (log4net.Appender.IAppender appender in repository.GetAppenders())
                {
                    if (appender.Name.CompareTo(appenderName) == 0 && appender is log4net.Appender.FileAppender)
                    {
                        log4net.Appender.FileAppender fileAppender = (log4net.Appender.FileAppender)appender;
                        fileAppender.File = System.IO.Path.Combine(fileAppender.File, newFilename);
                        fileAppender.ActivateOptions();                   
                    }
                }           
            }
