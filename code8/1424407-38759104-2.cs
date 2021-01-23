    public class Class1
    {
        public string Fund_ID { get; set; }
        public string Fund_Name { get; set; }
        public List<Class2> Details { get; set; }
    }
    
    public class Class2
    {
        public string Date { get; set; }
        public string Amount { get; set; }
    }
