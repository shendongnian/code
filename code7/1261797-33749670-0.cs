    [DataContract]
    public class TestItem
    {
        [DataMember]
        public int itemInt { get; set; }
        [DataMember]
        public string itemString { get; set; }
        public TestItem() { }
        public TestItem(int _intVal, string _stringVal)
        {
            itemInt = _intVal;
            itemString = _stringVal;
        }
    }
    [DataContract]
    public class TestMain
    {
        [DataMember]
        public int mainInt { get; set; }
        [DataMember]
        public string mainString { get; set; }
        [DataMember]
        public List<TestItem> TestItem = new List<TestItem>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            string test;
            // Test classes
            TestMain main = new TestMain();
            main.mainInt = 123;
            main.mainString = "Hello";
            main.TestItem.Add(new TestItem(1, "First"));
            test = Newtonsoft.Json.JsonConvert.SerializeObject(main);
            Console.WriteLine(test);
        }
    }
