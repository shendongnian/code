    public class Car
    {
        public int ID { get; set; }
    
        public int? ActiveTestRunID { get; set; }
        public virtual TestRun ActiveTestRun { get; set; }
    
        [InverseProperty("Car")]
        public virtual ICollection<TestRun> TestRuns { get; set; }
    }
    
    
    public class TestRun
    {
        public int ID { get; set; }
        public double TopSpeed { get; set; }
    
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
    }
