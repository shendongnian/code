        public static void SetThreadContextAndLog(LoggingSources eventId, Action logAction)
        {
            if (logAction != null)
            {
                log4net.ThreadContext.Properties[EVENT_ID_KEY] = (int)eventId;
                try
                {
                    SetEventSource(eventId.ToString());
                    logAction(); 
                }
                finally
                {
                    log4net.ThreadContext.Properties[EVENT_ID_KEY] = DEFAULT_EVENT_ID;
                }
            }
        }
