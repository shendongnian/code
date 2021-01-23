    class Program
        {
            static void Main(string[] args)
            {
                var context = new MyContext();
                foreach(var b in context.Bs)
                {
                    Console.WriteLine(b.ToString());
                }
            }
        }
    
        public class MyContext : DbContext
        {
            public DbSet<C> Cs { get; set; }
            public DbSet<B> Bs { get; set; }
        }
