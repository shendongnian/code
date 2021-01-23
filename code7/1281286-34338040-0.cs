    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Config())
            {
                // foreach (var demo in db.Demos) uncomment this, and comment the below line, to make it throw
                foreach (var demo in db.Demos.ToList()) // doing this makes it work, since the first query is done and the connection closed
                {
                    Console.WriteLine(demo.Name);
                    var s = db.Demo2s.FirstOrDefault(d => d.id == demo.demo2ID);
                    Console.WriteLine(s.Name + " " + s.id);
                }
    
                foreach (var demo2 in db.Demo2s)
                {
                    Console.WriteLine(demo2.id + " " + demo2.Name);
                }
            }
    
            Console.ReadKey();
        }
    }
    public class Config : DbContext
    {
        public Config()
            : base("test")
        { }
    
        public DbSet<demo> Demos { get; set; }
        public DbSet<demo2> Demo2s { get; set; }
    }
    internal sealed class Configuration : DbMigrationsConfiguration<ConsoleApplication1.Config>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    
        protected override void Seed(ConsoleApplication1.Config context)
        {
            List<demo2> d2 = new List<demo2>
            {
                new demo2 {Name = "One"},
                new demo2 {Name = "Two"},
                new demo2 {Name = "Three"}
            };
    
            foreach (var demo in d2)
            {
                context.Demo2s.Add(demo);
            }
    
            context.SaveChanges();
    
            List<demo> e = new List<demo>
            {
                new demo {Name = "First", demo2ID = 1},
                new demo {Name = "Second", demo2ID = 2},
                new demo {Name = "Third" , demo2ID = 3}
            };
    
            foreach (var demo in e)
            {
                context.Demos.Add(demo);
            }
    
            context.SaveChanges();
    
        }
    }
