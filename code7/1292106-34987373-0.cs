    public class BugReport
    {
        public BugReport()
        {
            dublicates = new HashSet<DublicateBugReport>();
        }        
    
        public int ID { get; set; }
        public virtual ICollection<DublicateBugReport> dublicates { get; set; }
    }
    
    public class DublicateBugReport
    {
        public DublicateBugReport()
        {
            reports = new HashSet<BugReport>();
        }        
    
        public int ID { get; set; }
        public virtual ICollection<BugReport> reports { get; set; }
    }
