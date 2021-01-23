    public class Metadata
    {
        public string type { get; set; }
    }
    
    public class ABCItem
    {
        public Metadata __metadata { get; set; }
        public string Priority { get; set; }
        (...)
    }
