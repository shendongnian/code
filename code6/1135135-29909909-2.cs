    class TestContext : DbContext
    {
        public TestContext()
            : base()
        {}
    
        public DbSet<ParentEntity> Parent { get; set; }
        public DbSet<ChildEntity> Child { get; set; }    
    }
