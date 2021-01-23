    public static class JsonExtensions
    {
        public static dynamic ToJson(this object input) => 
             System.Web.Helpers.Json.Decode(System.Web.Helpers.Json.Encode(input));
        static int Main(string[] args) {
             dynamic d = new Foo() { IsFool = true }.ToJson();
             Console.WriteLine(d.IsFool); //prints True
             Console.WriteLine(d.IsSpecial ?? "null"); //prints null
        }
    }
    class Foo
    {
        public bool IsFool { get; set; }
    }
 
