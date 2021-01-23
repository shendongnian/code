    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, int, UserLogin, UserRole, UserClaim>
    {
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //troca todos os campos NVARCHAR por varchar
            modelBuilder.Properties().Where(x =>
              x.PropertyType.FullName.Equals("System.String") &&
             !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Where(q => q.TypeName != null && q.TypeName.Equals("varchar(max)", StringComparison.InvariantCultureIgnoreCase)).Any())
              .Configure(c =>
                 c.HasColumnType("varchar(65000)"));
            modelBuilder.Properties().Where(x =>
              x.PropertyType.FullName.Equals("System.String") &&
             !x.GetCustomAttributes(false).OfType<ColumnAttribute>().Where(q => q.TypeName != null && q.TypeName.Equals("nvarchar", StringComparison.InvariantCultureIgnoreCase)).Any())
              .Configure(c =>
                 c.HasColumnType("varchar"));
        }
        public ApplicationDbContext()  : base("DefaultConnection")
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
