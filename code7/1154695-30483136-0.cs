    public class TestRequest
    {
        public TestRequest()
        {
            this.something = "SomethingDefault";
        }
        
        public string id { get; set; }
    
        [DefaultValue("SomethingDefault")]
        public string something { get; set; }
    }
