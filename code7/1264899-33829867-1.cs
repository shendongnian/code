    static void Main(string[] args)
    {
        string json = "{\"Html\":\"Hello<b>User</p>\" }";
        var myClass = JsonConvert.DeserializeObject<MyClass>(json);
    }
    
    public class MyClass
    {
        public string Html { get; set; }
        public string MyProperty { get; set; }
    }
