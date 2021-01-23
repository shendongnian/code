    class Program
    {
        static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                Id = 1,
                Bars = new List<Bar>
                {
                    new Bar
                    {
                        Id = 10,
                        FooBars = new List<FooBar>
                        {
                            new FooBar { Id = 100 },
                            new FooBar { Id = 101 }
                        }
                    },
                    new Bar
                    {
                        Id = 11,
                        FooBars = new List<FooBar>
                        {
                            new FooBar { Id = 110 },
                            new FooBar { Id = 111 },
                        }
                    }
                }
            };
            
            // Dictionary mapping class names to table names.
            Dictionary<string, string> tableNames = new Dictionary<string, string>();
            tableNames.Add(typeof(Foo).FullName, "Foos");
            tableNames.Add(typeof(Bar).FullName, "Bars");
            tableNames.Add(typeof(FooBar).FullName, "FooBars");
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new TableNameInsertionResolver(tableNames);
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
        }
    }
    public class Foo
    {
        // ...
        public int Id { get; set; }
        public virtual ICollection<Bar> Bars { get; set; }
    }
    public class Bar
    {
        // ...
        public int Id { get; set; }
        public virtual ICollection<FooBar> FooBars { get; set; }
    }
    public class FooBar
    {
        // ...
        public int Id { get; set; }
    }
