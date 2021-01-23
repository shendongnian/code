    class Program
    {
        static void Main(string[] args)
        {
            string json = @"
            {
                ""Template"": ""TemplateName""
            }";
            Console.WriteLine("--- first run ---");
            MyClass obj = JsonConvert.DeserializeObject<MyClass>(json);
            Dump(obj);
            json = @"
            {
                ""Template"": { ""Name"": ""OtherTemplate"" }
            }";
            Console.WriteLine("--- second run ---");
            obj = JsonConvert.DeserializeObject<MyClass>(json);
            Dump(obj);
        }
        static void Dump(MyClass obj)
        {
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
