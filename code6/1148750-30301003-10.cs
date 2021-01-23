    public class ClassB
    {
        public int Id { get; set; }
        [DefaultValue("NOTSET")]
        public string SomeString { get; set; }
        public int? SomeInt { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string str = "{ 'Id':5 }";
            var myObject = JsonConvert.DeserializeObject<ClassB>(str
                , new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Populate
                });
            if (myObject.SomeString == "NOTSET")
            {
                Console.WriteLine("no value provided for property SomeString");
            }
            Console.ReadKey();
        }
    }
