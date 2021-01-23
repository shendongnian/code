    public class SummaryContext
    {
        public string tenant { get; set; }
    }
    
    public class Data
    {
        public string LOST_TO_COMPETITOR { get; set; }
        public string OTHER { get; set; }
        public string DISCONTINUED { get; set; }
        public string SERVICE_ISSUES { get; set; }
        public string SEASONAL { get; set; }
    }
    
    public class RejectReasonCodesResponse
    {
        public string responseID { get; set; }
        public string timestamp { get; set; }
        public string type { get; set; }
        public Context context { get; set; }
        public Data data { get; set; }
    }
