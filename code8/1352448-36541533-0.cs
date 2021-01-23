    class Program
    {
        public class Foo
        {
            public string Name { get; set; }
            public double Value { get; set; }
    
            public override string ToString()
            {
                return Name;
            }
        }
    
        static void Main(string[] args)
        {
            Foo foo1 = new Foo { Name = "Foo1", Value = 2.2 };
            Foo foo2 = new Foo { Name = "Foo2", Value = 3.6 };
    
            var dic = new Dictionary<string, KeyValuePair<Foo, int>>();
            dic.Add(foo1.Name, new KeyValuePair<Foo, int>(foo1, 1234));
            dic.Add(foo2.Name, new KeyValuePair<Foo, int>(foo2, 2345));
    
            int x = dic["Foo1"].Value;
    
            var y = dic["Foo2"].Value;
    
            Console.WriteLine(x);
            Console.WriteLine(y);
    
            Console.ReadKey();
        }
    }
