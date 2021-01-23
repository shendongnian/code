    public class MyService : IService
    {
    	private readonly IRepositoryFactory repositoryFactory;
    
    	public MyService(IRepositoryFactory repositoryFactory)
    	{
    		this.repositoryFactory = repositoryFactory;
    	}
    	
    	public void BusinessMethod()
    	{
    		using (var repo = this.repositoryFactory.Create())
    		{
    			// ...
    		}
    	}
    }
    
    public interface IRepositoryFactory
    {
    	IRepository Create();
    }
