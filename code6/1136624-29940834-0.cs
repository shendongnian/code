    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var mainClass = new MainClass();
    
                mainClass.b = new List<B>();
                mainClass.c = new List<C>();
                mainClass.b.Add(new B { ID = 1, Address = "B1" });
                mainClass.c.Add(new C { ID = 1, Name = "C1" });
    
                //using LINQ
                var query = (from b in mainClass.b
                             join c in mainClass.c
                              on b.ID equals c.ID
                             select new A { MainAddress = c.Name });
    
                List<A> fromLINQ = query.ToList();
    
                //using anonymous functions aka lambda expressions
                IEnumerable<A> enumerableFromAnonymous = mainClass.b.Join(mainClass.c, x => x.ID, x => x.ID, (x, y) => { return new A() { MainAddress = y.Name }; });
                List<A> listFromAnonymous = enumerableFromAnonymous.ToList();
            }
        }
    
        public class MainClass
        {
            public List<A> a { get; set; }
            public List<B> b { get; set; }
            public List<C> c { get; set; }
        }
    
        public class A
        {
            public string Name { get; set; }
            public string MainAddress { get; set; }
        }
    
        public class B
        {
            public int ID { get; set; }
            public string Address { get; set; }
        }
    
        public class C
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
