    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = new IPAddress("192.168.1.2");
            var obj = new SomeOuterObject() { stringValue = "Some String", ipValue = ip };
            string json = JsonConvert.SerializeObject(obj);
            Console.WriteLine(json);
        }
    }
    public class SomeOuterObject
    {
        public string stringValue { get; set; }
        public IPAddress ipValue { get; set; }
    }
