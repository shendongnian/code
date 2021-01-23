    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- first run ---");
            
            string json = @"
            {
                ""Template"": ""TemplateName""
            }";
            DeserializeAndDump(json);
            Console.WriteLine("--- second run ---");
            json = @"
            {
                ""Template"": { ""Name"": ""OtherTemplate"" }
            }";
            DeserializeAndDump(json);
        }
        static void DeserializeAndDump(string json)
        {
            MyClass obj = JsonConvert.DeserializeObject<MyClass>(json);
            if (obj.Template == null)
            {
                Console.WriteLine("Template property is null");
            }
            else
            {
                Console.WriteLine("Template property is a " + obj.Template.GetType().Name);
                string name = "(unknown)";
                if (obj.Template is Template) name = ((Template)obj.Template).Name;
                else if (obj.Template is string) name = (string)obj.Template;
                Console.WriteLine("Template name is \"" + name + "\"");
            }
            Console.WriteLine();
        }
    }
    class Template
    {
        public string Name { get; set; }
    }
