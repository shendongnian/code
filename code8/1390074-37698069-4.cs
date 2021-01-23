    static void Main(string[] args)
            {
                var c = new MyClass()
                {
                    rows = new List<List<string>>()
                    {
                        new List<string>() {"string1","string2","string3" }
                    }
    
                };
                Console.WriteLine(JsonConvert.SerializeObject(c));
                Console.Read();
    
            }
    
            public class MyClass
            {
                public List<List<string>> rows { get; set; }
            }
