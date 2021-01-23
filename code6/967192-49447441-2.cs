     class Program
    {
        static void Main(string[] args)
        {
            var  testDictionary = new Dictionary<TestKey,TestValue>()
            {
                {
                    new TestKey()
                    {
                        TestKey1 = "1",
                        TestKey2 = "2",
                        TestKey5 = 5
                    },
                    new TestValue()
                    {
                        TestValue1 = "Value",
                        TestValue5 = 96
                    }
                }
            };
            var json = JsonConvert.SerializeObject(testDictionary);
            Console.WriteLine("=== Dictionary<TestKey,TestValue> ==");
            Console.WriteLine(json);
            // result: {"ConsoleApp2.TestKey":{"TestValue1":"Value","TestValue5":96}}
            json = JsonConvert.SerializeObject(testDictionary.ToList());
            Console.WriteLine("=== List<KeyValuePair<TestKey, TestValue>> ==");
            Console.WriteLine(json);
            // result: [{"Key":{"TestKey1":"1","TestKey2":"2","TestKey5":5},"Value":{"TestValue1":"Value","TestValue5":96}}]
            Console.ReadLine();
        }
    }
    class TestKey
    {
        public string TestKey1 { get; set; }
        public string TestKey2 { get; set; }
        public int TestKey5 { get; set; }
    }
    class TestValue 
    {
        public string TestValue1 { get; set; }
        
        public int TestValue5 { get; set; }
    }
    
