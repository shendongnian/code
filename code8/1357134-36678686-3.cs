        public static void LogEvent(LoggingSources pEvent, string pMessage, EventLogEntryType pEventType)
        {
            SetThreadContextAndLog(pEvent, () =>
            {
                if (pEventType == EventLogEntryType.Warning)
                {
                    Log.Warn(pMessage);
                }
            });
        }
