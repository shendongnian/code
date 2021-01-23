    internal class ClientDesktopContainer : WindsorContainer
    {
        public ClientDesktopContainer()
        {
            RegisterComponents();
        }
    
        private void RegisterComponents()
        {
            var connectionstring = ConfigurationManager.ConnectionStrings["MyDbContext"].ConnectionString;
    
             /* HERE CALL TO REGISTER: */
             this.Register(
            // Data Onion
            Component.For<IDbContextFactory>().ImplementedBy<DbContextFactory>()
                .DependsOn(new DbContextConfig(connectionstring, typeof(MyDbContext), new MigrateToLatestVersion(new Seeder()))),
            Component.For<IDbContextScope>().ImplementedBy<DbContextScope>(),
            Component.For<IDbContextScopeFactory>().ImplementedBy<DbContextScopeFactory>(),
            Component.For<IAmbientDbContextLocator>().ImplementedBy<AmbientDbContextLocator>(),
            Component.For<IDbContextReadOnlyScope>().ImplementedBy<DbContextReadOnlyScope>(),
    
            // Data Onion Unit of Work
            Component.For<IRepositoryLocator>().ImplementedBy<RepositoryLocator>(),
            // Component.For<IRepositoryResolver>().ImplementedBy<CastleWindsorRepositoryResolver>(),
            Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>(),
            Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>(),
            Component.For<IReadOnlyUnitOfWork>().ImplementedBy<IReadOnlyUnitOfWork>(),
    
            // Custom
            Component.For<IRepository<Enrollment>>()
                     .ImplementedBy<BaseRepository<Enrollment, MyDbContext>>() );
    }
