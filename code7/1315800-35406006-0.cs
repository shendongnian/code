    List<string> stringLogs = 
        ev.Entries
            .Where(t => t.InstanceId == 1149)
            .Select(t => GenerateLogString(t))
            .ToList();
    public string GenerateLogString(EventLogEntry CurrentEntry)
    {
        return
            string.Format("Event type: {0}\nEvent Message: {1}\nEvent Time: {2}\nEvent: {3}\n",
                CurrentEntry.EntryType.ToString(),
                CurrentEntry.Message + CurrentEntry,
                CurrentEntry.TimeGenerated.ToShortTimeString(),
                CurrentEntry.UserName)
    }
