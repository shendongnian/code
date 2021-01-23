    public class ClassA
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
            const string str = "{'Id':5, 'FooBar': 42 }";
            var myObject = JsonConvert.DeserializeObject<ClassA>(str
                , new JsonSerializerSettings
                {
                    Error = OnError,
                    MissingMemberHandling = MissingMemberHandling.Error,
                    DefaultValueHandling = DefaultValueHandling.Populate
                });
            if (myObject.SomeString == "NOTSET")
            {
                Console.WriteLine("no value provided for property SomeString");
            }
            Console.ReadKey();
        }
        private static void OnError(object sender, ErrorEventArgs args)
        {
            Console.WriteLine(args.ErrorContext.Error.Message);
            args.ErrorContext.Handled = true;
        }
    }
