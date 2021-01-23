    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MyContext())
            {
                var foo = new Foo()
                {
                    Name = "Foo",
                    Bars = new[]
                    {
                        new Bar() { Name = "Bar1" },
                        new Bar() { Name = "Bar2" },
                    
                    }
                };
                context.Foos.Add(foo);
                context.SaveChanges();
            }
            using (var context = new MyContext())
            {
                foreach (var x in context.Bars.ToList())
                {
                    Console.Out.WriteLine("Id: {0}, Name: {1}", x.Id, x.Name);
                }
            }
            Console.ReadKey();
        }
    }
    public class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Bar> Bars { get; set; }
    }
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Foo Foo { get; set; }
    }
    public class MyContext : DbContext
    {
        public MyContext()
        {
            Database.SetInitializer<MyContext>(new DropCreateDatabaseAlways<MyContext>());
        }
        public virtual IDbSet<Foo> Foos { get; set; }
        public virtual IDbSet<Bar> Bars { get; set; }
    }
