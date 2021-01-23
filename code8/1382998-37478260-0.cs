    public class A
    {
        public int AId { get; set; }
        public virtual B B { get; set; }
    }
    public class B
    {
        public int AId { get; set; }
        public virtual A A { get; set; }
        public virtual ICollection<C> Cs { get; set; }
    }
    public class C
    {
        public int Id { get; set; }
        public int BId { get; set; }
        public virtual B B { get; set; }
    }
    public class MyDb : DbContext
        {
            public DbSet<A> As { get; set; }
            public DbSet<B> Bs { get; set; }
            public DbSet<C> Cs { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<B>()
                    .HasKey(p => p.AId);
                modelBuilder.Entity<A>()
                    .HasOptional(p => p.B)
                    .WithRequired(p => p.A);
                modelBuilder.Entity<C>()
                    .HasRequired(p => p.B)
                    .WithMany(p => p.Cs)
                    .HasForeignKey(p => p.BId);
            }
        }
