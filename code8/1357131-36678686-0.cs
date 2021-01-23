        private static void SetEventSource(string sourceName)
        {
            var repository = LogManager.GetRepository();
            if (repository != null)
            {
                var appender = repository.GetAppenders().Where(x => x.Name == "eventLogAppender").FirstOrDefault();
                if (appender is log4net.Appender.EventLogAppender)
                {
                    var eventAppender = (log4net.Appender.EventLogAppender)appender;
                    eventAppender.ApplicationName = sourceName;
                    eventAppender.ActivateOptions();
                }
            }
        }
