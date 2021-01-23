    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"d\":[{title:\"test\",description:\"test desc\"},{title:\"test2\",description:\"desc test 2\"}]}";
            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(json);
        }
    }
    public class Rootobject
    {
        public D[] d { get; set; }
    }
    public class D
    {
        public string title { get; set; }
        public string description { get; set; }
    }
