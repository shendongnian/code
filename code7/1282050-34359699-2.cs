    public class Context : DbContext
    {
        public DbSet<FluxoPrincipal> FluxoPrincipal { get; set; }
        public DbSet<FluxoAlternativo> FluxoAlternativo { get; set; }
        public DbSet<FluxoDeExcecao> FluxoDeExcecao { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
    public class FluxoPrincipalMap : EntityTypeConfiguration<FluxoPrincipal>
    {
        public FluxoPrincipalMap()
        {
            HasKey(x => x.FluxoID);
            Map(x => x.MapInheritedProperties());
        }
    }
    public class FluxoAlternativoMap : EntityTypeConfiguration<FluxoAlternativo>
    {
        public FluxoAlternativoMap()
        {
            HasKey(x => x.FluxoID);
            Map(x => x.MapInheritedProperties());
        }
    }
    class FluxoDeExcecaoMap : EntityTypeConfiguration<FluxoDeExcecao>
    {
        public FluxoDeExcecaoMap()
        {
            HasKey(x => x.FluxoID);
            Map(x => x.MapInheritedProperties());
        }
    }
