    public class TestRequest
    {
        public string id { get; set; }
    
        [DefaultValue("SomethingDefault")]
        public string something { get; set; } = "SomethingDefault";
    }
