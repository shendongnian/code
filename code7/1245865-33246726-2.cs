    class Program
    {
        static void Main(string[] args)
        {
            var test = new MyTestObject();
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new CustomResolver();
            settings.Formatting = Formatting.Indented;
            var json = JsonConvert.SerializeObject(test, settings);
            Console.WriteLine(json);
        }
        class MyTestObject
        {
            [SerializeOnly("TestValue1")]
            [SerializeOnly("TestValue3")]
            public ComplexTestObject Property1 { get; set; }
            [SerializeOnly("TestValue2")]
            public ComplexTestObject Property2 { get; set; }
            public MyTestObject()
            {
                Property1 = new ComplexTestObject();
                Property2 = new ComplexTestObject();
            }
        }
        class ComplexTestObject
        {
            public string TestValue1 { get; set; }
            public string TestValue2 { get; set; }
            public string TestValue3 { get; set; }
            public ComplexTestObject()
            {
                TestValue1 = "value1";
                TestValue2 = "value2";
                TestValue3 = "value3";
            }
        }
    }
