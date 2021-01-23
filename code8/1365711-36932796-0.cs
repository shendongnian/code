            // Get the Hierarchy object that organizes the loggers
            Hierarchy hier = log4net.LogManager.GetRepository() as Hierarchy;
            var smtpappender =
                    (SmtpAppender)hier.GetAppenders().Where(
                        appender => appender.Name.Equals("LogSmtpAppender", StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                if (smtpappender != null)
                {
                    // Change your setting here
                    smtpappender.To = "new@value.com"
                    // Activate the options
                    smtpappender.ActivateOptions(); 
                }
            }
            
