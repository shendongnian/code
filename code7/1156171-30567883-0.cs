    public class CompanyDetails
    {
        public int ID { get; set; }
    
        public int MSSCompanyID { get; set; }
    
        public int CircuitID { get; set; }
    
        public string CompanyName { get; set; }
    
        public Metric[] Metrics { get; set; }
    }
    
    public class Metric
    {
        public int LongId { get; set; }
    
        public string Unit { get; set; }
    
        public string Name { get; set; }
    }
