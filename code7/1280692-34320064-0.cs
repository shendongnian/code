        public class LogParameters
        {
            public int UserId { get; set; }
            public int SiteId { get; set; }
        }
        public void CreateLog(string message, LogParameters parameters)
