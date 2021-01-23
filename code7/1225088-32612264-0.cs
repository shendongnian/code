    public partial class ProjectMgtContext : DbContext {
        public static string DefaultConnectionString;
        public TestEntities()
            : base(DefaultConnectionString)
        {
     }
