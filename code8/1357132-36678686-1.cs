        public static void ConfigureWindowsEvents()
        {
            // Create event log sources for each of our Logging types
            var loggingEvents = Enum.GetValues(typeof(LoggingSources));
            foreach (var item in loggingSources)
            {
                string source = item.ToString();
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, EVENT_LOG_NAME);
                }
            }
        }
