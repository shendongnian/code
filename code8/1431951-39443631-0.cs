    public class Program
    {
        public static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                CamelCasedProperty = "abc def",
                AlsoCamelCasedButChildPropsAreNot = new Bar
                {
                    SomeProperty = "fizz buzz",
                    AnotherProperty = "whiz bang"
                },
                ThisOneOptsOutOfCamelCasing = "blah blah",
                ThisOneIsSnakeCased = "senssssational"
            };
            var settings = new JsonSerializerSettings
            {
                // set up default naming scheme
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
        }
    }
    class Foo
    {
        public string CamelCasedProperty { get; set; }
        public Bar AlsoCamelCasedButChildPropsAreNot { get; set; }
        [JsonProperty(NamingStrategyType = typeof(DefaultNamingStrategy))]
        public string ThisOneOptsOutOfCamelCasing { get; set; }
        [JsonProperty(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
        public string ThisOneIsSnakeCased { get; set; }
    }
    [JsonObject(NamingStrategyType = typeof(DefaultNamingStrategy))]
    class Bar
    {
        public string SomeProperty { get; set; }
        public string AnotherProperty { get; set; }
    }
