    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            { 
                ""Name"" : ""<b>Foo Bar</b>"", 
                ""Description"" : ""<p>Bada Boom Bada Bing</p>"", 
            }";
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CustomResolver()
            };
            Foo foo = JsonConvert.DeserializeObject<Foo>(json, settings);
            Console.WriteLine("Name: " + foo.Name);
            Console.WriteLine("Desc: " + foo.Description);
        }
    }
    class Foo
    {
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
    }
    class AllowHtmlAttribute : Attribute { }
