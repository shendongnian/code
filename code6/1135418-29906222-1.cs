        public class EfContext : DbContext
        {
            public EfContext()
                : base("Gallery.SqlServer")
            {
            
            }
            public DbSet<Foo> Foos { get; set; }
        }
