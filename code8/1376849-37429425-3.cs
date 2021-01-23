    namespace OracleTestExeConfigAndConnStr
    {
      [DbConfigurationType(typeof(OracleDBConfiguration))]
      public class GlobalAttributeContext : DbContext
      {
        public DbSet<GlobalAttribute>  GlobalAttributes { get; set; }
        static GlobalAttributeContext()
        {
          Database.SetInitializer<GlobalAttributeContext>(null);
        }
        public GlobalAttributeContext() : base("OracleDbContext")
        {
        }
        public GlobalAttributeContext(string nameOrConnectionString)
               : base(nameOrConnectionString)
        {
        }
        public GlobalAttributeContext(DbConnection existingConnection, bool contextOwnsConnection)
               : base(existingConnection, true)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          // We have to pass the schema name into the configuration. (Is there a better way?)
          modelBuilder.Configurations.Add(new GlobalAttribute_Config_Oracle("SchemaName")) ;
        }
      }
    }
