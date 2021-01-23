    public abstract class FooServicesProvider
    {
        public Func<IServiceProvider, IRepository<Database>> DatabaseRepository { get; protected set; } 
    }
    public class FooFileSystemServicesProvider : FooServicesProvider
    {
        public FooFileSystemServicesProvider()
        {
            base.DatabaseRepository = GetDatabaseRepository;
        }
        private DatabaseFileSystemRepository GetDatabaseRepository(IServiceProvider serviceProvider)
        {
            //Specific code determining which database to use and create a new one if needed
            //our databases are FOLDERS containing some files
            //knowing how chosenDb.FullName is set is not important here
            //[...]
            var databaseRepository = new DatabaseFileSystemRepository(chosenDb.FullName);
            databaseRepository.testProperty = "Foo value";
            return databaseRepository;
        }        
    }
