        private static readonly object _configLogLock = new object();
        private void UpdateLastEventId(IList<EventLogEntry> entries)
        {
            if (entries.Count > 0)
            {
                EventLogEntry lastEntry = entries[entries.Count - 1];
                lock (_configLogLock)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var configSettings = config.AppSettings.Settings;
                    string key = string.Format(CultureInfo.InvariantCulture, "{0}|{1}", _eventLogFilter.EventLog, _eventLogFilter.MD5Hash);
                    if (configSettings[key] == null)
                    {
                        configSettings.Add(key, lastEntry.Index.ToString(CultureInfo.InvariantCulture));
                    }
                    else
                    {
                        configSettings[key].Value = lastEntry.Index.ToString(CultureInfo.InvariantCulture);
                    }
                    config.Save(ConfigurationSaveMode.Modified);//Error seems to happen here
                }
            }
        }
