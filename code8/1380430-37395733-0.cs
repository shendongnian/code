        private void readEventLogs()
        {
            string query = "*[System/EventID=1074]";
            EventLogQuery elq = new EventLogQuery("System", PathType.LogName, query);
            EventLogReader elr = new EventLogReader(elq);
            EventRecord entry;
            while ((entry = elr.ReadEvent()) != null)
            {
                if (entry.TimeCreated.HasValue && entry.TimeCreated.Value.AddMinutes(1) > DateTime.Now)
                {
                    string xml = entry.ToXml();
                    if (xml.ToLower().Contains("restart"))
                    {
                        System.IO.File.WriteAllLines(@"C:\shutdown.txt", new string[] { "RESTART" });
                    }
                    else if (xml.ToLower().Contains("power off"))
                    {
                        System.IO.File.WriteAllLines(@"C:\shutdown.txt", new string[] { "SHUT DOWN" });
                    }
                }
            }
        }
