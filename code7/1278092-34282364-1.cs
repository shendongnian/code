    /// <summary>
    /// Base entity, not used by EF at all - intended to define properties only.
    /// </summary>
    public class MyEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// That entity used to create primary table and used by app logic.
    /// </summary>
    public class MyEntity : MyEntityBase
    {
    }
    /// <summary>
    /// That entity used to create temp table only.
    /// </summary>
    public class MyTempEntity : MyEntityBase
    {
    }
    /// <summary>
    /// Here is our DB context with two DbSets...
    /// </summary>
    public class MyDbContext : DbContext
    {
        /// <summary>
        /// That DbSet should be used by app logic.
        /// </summary>
        public DbSet<MyEntity> MyEntities { get; set; }
        /// <summary>
        /// That DbSet will force EF to create temp table.
        /// App logic shouldn't interact with it in common way 
        /// (only SqlBulkCopy and some hand-written queries) 
        /// so it is not public.
        /// </summary>
        protected DbSet<MyTempEntity> MyTempEntities { get; set; }
    }
