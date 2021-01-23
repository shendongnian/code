    public class CompositedDataContextInitializer : MigrateDatabaseToLatestVersion<DataContext, Migrations.MigrationConfiguration>
    {
        protected virtual void Seed(DataContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            foreach (var seeder in ServiceLocator.Current.GetAllInstances<IDataSeeder>())
            {
                seeder.Seed(context);
            }
        }
    }
    [Export(typeof(IDbContextFactory<DbContext>))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ContextFromCompositionFactory : IDbContextFactory<DbContext>, IDbContextFactory<DataContext>
    {
        public DbContext Create() => new DataContext(ServiceLocator.Current.GetAllInstances<IModelCreator>(), new CompositedDataContextInitializer());
        DataContext IDbContextFactory<DataContext>.Create() => (DataContext)Create();
    }
    public interface IModelCreator
    {
        void OnModelCreating(DbModelBuilder modelBuilder);
    }
    public class DataContext : DbContext
    {
        public DataContext(IEnumerable<IModelCreator> modelCreators, IDatabaseInitializer<DataContext> initializer)
        {
            ModelCreators = modelCreators;
            if (initializer != null)
            {
                Database.SetInitializer(initializer);
            }
        }
    
        private IEnumerable<IModelCreator> ModelCreators { get; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
    
            foreach (var creator in ModelCreators)
            {
                creator.OnModelCreating(modelBuilder);
            }
        }
    }
