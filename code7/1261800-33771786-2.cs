    public class TestItem
    {
        
        public int itemInt { get; set; }
        
        public string itemString { get; set; }
        public TestItem() { }
        
        public TestItem(int _intVal, string _stringVal)
        {
            itemInt = _intVal;
            itemString = _stringVal;
        }
    }
    public class Testmain
    {
        
       public int mainInt { get; set; }
        
        public string mainString { get; set; }
        
        public List<TestItem> TestItem = new List<TestItem>();
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            string test;
            // Test classes
            Testmain main = new Testmain();
            main.mainInt = 123;
            main.mainString = "Hello";
            main.TestItem.Add(new TestItem(1, "First"));
            test = Newtonsoft.Json.JsonConvert.SerializeObject(main);
            Console.WriteLine(test);
            return JsonConvert.SerializeObject(main);
        }...
