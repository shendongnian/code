    public CustomDbContext : IdentityDbContext
    {
        public virtual DbSet<Table1> Table1 { get; set; }
        public virtual DbSet<Table2> Table2 { get; set; }
    }
