            private static void ToggleAuditing(bool enabled)
        {
            log4net.Appender.IAppender[] appenders = log4net.LogManager.GetRepository().GetAppenders();
            foreach (log4net.Appender.IAppender app in appenders)
            {
                log4net.Appender.AppenderSkeleton skel = app as log4net.Appender.AppenderSkeleton;
                if (skel != null && app.Name.StartsWith("Audit"))
                {
                    skel.Threshold = enabled ? Level.All : Level.Off;
                }
            }
        }
