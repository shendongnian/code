         public class DbContexFor : DbContext
            {    
                public DbContexFor()
                    : base("name=ConnectionStringName")
                {
                }
    
                public virtual DbSet<User> Users { get; set; }
                public virtual DbSet<Wepon> Wepons { get; set; }
            }
            }
