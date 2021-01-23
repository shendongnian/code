    void Main()
    {
        using (var session = new EventLogSession("remote server name"))
        {
            GetCompletedScheduledTaskEventRecords(session, "Your scheduled tasks name")
                .OrderByDescending(x => x.TimeCreated)
                .Select(r => new { CompletedTime = r.TimeCreated, r.TaskDisplayName, Props = string.Join(" | ", r.Properties.Select(p => p.Value)) })
                .Dump("Said Tasks Completed"); //using linqpad's Dump method, this just outputs the results to the display
        }
    }
    //If you don't want completed tasks remove the second part in the where clause
    private List<EventRecord> GetCompletedScheduledTaskEventRecords(EventLogSession session, string scheduledTask)
    {
        const int TASK_COMPLETED_ID = 102;
        var logquery = new EventLogQuery("Microsoft-Windows-TaskScheduler/Operational", PathType.LogName, "*[System/Level=4]") { Session = session };
        return GetRecords(logquery, 
            x=> x.Properties.Select(p => p.Value).Contains($@"\{scheduledTask}") && x.Id == TASK_COMPLETED_ID).ToList();
    }
    private IEnumerable<EventRecord> GetRecords(EventLogQuery query, Func<EventRecord, bool> filter)
    {
        using (var reader = new EventLogReader(query))
        {
            for (var record = reader.ReadEvent(); null != record; record = reader.ReadEvent())
            {
                if (!filter(record)) continue;
                yield return record;
            }
        }
    }
