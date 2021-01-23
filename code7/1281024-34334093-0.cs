    public class Visit
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public BrowserType BrowserType { get; set; }
        public String Duration { get; set; }
    
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    
        public Visit()
        {
            DateTime = DateTime.Now;
            BrowserType = BrowserType.Other;
        }
    }
