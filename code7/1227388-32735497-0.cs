    public class RootObject
    {
        public int field1_Class1 { get; set; }
        public int field2_Class1 { get; set; }
        public int field3_Class1 { get; set; }
        public int field4_Class1 { get; set; }
        public int field5_Class1 { get; set; }
        public int field6_Class1 { get; set; }
        public int field1_Class2 { get; set; }
        public string field2_Class2 { get; set; }
        public string field3_Class2 { get; set; }
        public string field4_Class2 { get; set; }
        public string field5_Class2 { get; set; }
    }
    var type = JsonConvert.DeserializeObject<RootObject>(new StreamReader("jsonPath").ReadToEnd());
