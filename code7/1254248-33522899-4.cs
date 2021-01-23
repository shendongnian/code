    class Program
    {
        static void Main(string[] args)
        {
            // Reproducing your 'Records' collection for testing
            var Records = new Collection<string>
            {
                "username:\t\tgerald\r\n\t\t\t0x18ECC03\r\n\t",
                "username:\t\tjason\r\n\t\t\t0x18ECC03\r\n\t",
            };
            string[] userList={"gerald","admin","john"} ;
            List<EventItem> logall= new List<EventItem>();
            List<EventItem> logfilteruser= new List<EventItem>();
            // Contains both records
            logall= Records.AsQueryable().Select(e => new EventItem(e)).ToList();
            // Only contains "username:\t\tjason\r\n\t\t\t0x18ECC03\r\n\t"
            //  as the other record contains 'jason', which is in userlist
            logfilteruser = logall.Where(x => !userList.Any(u => x.depict.Contains(u))).ToList();
        }
    }
    public class EventItem
    {
        public EventItem(string depict)
        {
            this.depict = depict;
        }
        public string depict { get; set; }
    }
