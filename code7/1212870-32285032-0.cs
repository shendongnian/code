    public class LogEntriesByTypeQuery : IQuery<LogEntry>
    {
        private readonly int type;
        public LogEntriesByTypeQuery(string type)
        {
            this.type = type;
        }
        public IEnumerable<LogEntry> Run(IQueryable<LogEntry> logEntries)
        {
            return (from e in logEntries
                where e.Type == type
                select e).ToList();
        }
    }
