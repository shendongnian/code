    class Program
    {
        static void Main(string[] args)
        {
            // Create some test data
            List<TestEventRecord> Records = new List<TestEventRecord>();
            Records.Add(new TestEventRecord { Value = "username:\t\tgerald\r\n\t\t\t0x18ECC03\r\n\t" });
            Records.Add(new TestEventRecord { Value = "username:\t\tjason\r\n\t\t\t0x18ECC03\r\n\t" });
            string[] userList = { "gerald", "admin", "john" };
            List<EventItem> logall = new List<EventItem>();
            List<EventItem> logfilteruser = new List<EventItem>();
            // Contains all entries
            logall = Records.AsQueryable().Select(e => new EventItem(e)).ToList();
            // Contains only 1 entry as the list is filtered
            logfilteruser = logall.Where(x => !userList.Any(u => x.depict.Contains(u))).ToList();
        }
    }
    public class EventItem
    {
        public int Id { get; set; }
        public string LogName { get; set; }
        public string depict { get; set; }
        public EventItem(TestEventRecord record)
        {
            Id = record.Id;
            LogName = record.LogName;
            depict = record.FormatDescription();
        }
    }
    public class TestEventRecord
    {
        public int Id { get; set; }
        public string LogName { get; set; }
        public string Value { get; set; }
        public string FormatDescription()
        {
            return Value;
        }
    }
