    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            context.Database.Initialize(true);
        }
    }
    public class Request
    {
        public int RequestId { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
        public virtual ICollection<Administrator> Administrators { get; set; }
    }
    public class Response
    {
        public int ResponseId { get; set; }
        public virtual Request Request { get; set; }
        public virtual Administrator Administrator { get; set; }
    }
    public class Administrator
    {
        public int AdministratorId { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RequestsConfig());
            modelBuilder.Configurations.Add(new AdministratorsConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
    public class RequestsConfig : EntityTypeConfiguration<Request>
    {
        public RequestsConfig()
        {
            HasMany(r => r.Responses).WithRequired(rs => rs.Request);
            HasMany(r => r.Administrators).WithMany(a => a.Requests);
        }
    }
    public class AdministratorsConfig: EntityTypeConfiguration<Administrator>
    {
        public AdministratorsConfig()
        {
            HasMany(a => a.Responses).WithRequired(r => r.Administrator);
        }
    }
