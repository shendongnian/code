    public class StubContext : DbContext {
        //...code removed for brevity
        public virtual DbSet<StubEntity> DbEntities { get; set; }
        //...other code removed for brevity
    }
