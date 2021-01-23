    public class MyDb: DbContext
    {
        public MyDb():base("EfDbContext")
        {           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Entity<Relationship>()
                .HasRequired(f => f.Activity1)
                .WithMany(f => f.Predecessors)
                .HasForeignKey(g => g.Activity1_ID)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Relationship>().
                 HasRequired(f => f.Activity2)
                .WithMany(f => f.Successors)
                .HasForeignKey(g => g.Activity2_ID)
                .WillCascadeOnDelete(false);
        }
    }
