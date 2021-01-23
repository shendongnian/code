    using System.Diagnostics.Eventing.Reader;
    public class EventLogTracker()
    {
        public List<MyEventLogQuery> Queries { get; set; }
        // ... snipped some stuff
        public int Run()
        {
            var count = 0;
            foreach (var myQuery in Queries)
            {
                var query = new EventLogQuery(myQuery.Log, myQuery.PathType, myQuery.Query);
                
                // This is the important bit. Must take account that the
                // log may have been empty, so bookmark could be null
                var reader = myQuery.Bookmark != null ? new EventLogReader(query, myQuery.Bookmark) : new EventLogReader(query);
                EventRecord eventRecord;
                while ((eventRecord = reader.ReadEvent()) != null)
                {
                    // Do stuff
                    // ...
                    // Then update the bookmark
                    myQuery.Bookmark = eventRecord.Bookmark;
                    count++;
                }
            }
            return count;
        }
