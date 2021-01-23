    [Serializable()]
    [XmlRoot("MyData", Namespace = "")]
    public class MyData
    {
        public MyData() { }
        public bool checkBox1State { get; set; }
        public bool checkBox2State { get; set; }
        public string radioGroupSelected { get; set; }
        public string button1Text { get; set; }
        ...
    }
