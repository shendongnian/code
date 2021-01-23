    public class ContainerRegistry : Registry
    {
    	#region <Constructors>
    
    	public ContainerRegistry()
    	{
    		Scan(
    			scan =>
    			{
    				scan.TheCallingAssembly();
    				scan.WithDefaultConventions();
    				scan.LookForRegistries();
    				scan.AssembliesFromApplicationBaseDirectory(f => f.FullName.StartsWith("Bushido.Common", true, null));
    				scan.AssembliesFromApplicationBaseDirectory(f => f.FullName.StartsWith("Bushido.Process", true, null));
    				scan.AddAllTypesOf(typeof(IAccountApplication));
    				scan.AddAllTypesOf(typeof(IAccountAlgorithm));
    				scan.SingleImplementationsOfInterface();
    			});
    
    		ForSingletonOf(typeof(IDbContext)).Use(typeof(DemoDbContext));
    
    		For(typeof(IDemoDbUnitOfWork)).Use(typeof(DemoDbUnitOfWork));
    		For(typeof(IRepository<>)).Use(typeof(GenericRepository<>));
    	}
    
    	#endregion
    }
