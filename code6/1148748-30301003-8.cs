    public class ClassA
    {
        public int Id { get; set; }
        public string SomeString { get; set; }
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
                    MissingMemberHandling = MissingMemberHandling.Error
                });
            Console.ReadKey();
        }
        private static void OnError(object sender, ErrorEventArgs args)
        {
            Console.WriteLine(args.ErrorContext.Error.Message);
            args.ErrorContext.Handled = true;
        }
    }
