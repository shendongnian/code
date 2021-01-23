            /// <summary>
            /// Get Last Wake Event Entry
            /// </summary>
            /// <param name="wakeMessage"></param>
            /// <returns></returns>
            private static EventLogEntry GetLastWakeEventEntry(out string[] wakeMessage)
            {
                wakeMessage = null;
                EventLogEntry wakeEntry = null;
                //Open system event log of current user
                var eventLog = new EventLog("System", ".");
                //Get all event log entries
                var entries = eventLog.Entries;
                //Start from the latest event message until finding the wake event log
                for (int i = entries.Count - 1; i >= 0; i--)
                {
                    if (entries[i].Source == "Microsoft-Windows-Power-Troubleshooter" && entries[i].InstanceId == 1)
                    {
                        wakeEntry = entries[i];
                        wakeMessage = Regex.Split(entries[i].Message, @"([\r\n])");
                        break;
                    }
                }
                return wakeEntry;
            }
