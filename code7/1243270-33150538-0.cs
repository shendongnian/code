    public class Test
    {
    	private readonly IRepository<User> _userRepository;
    
    	public Test(IRepository<User> userRepository)
    	{
    		_userRepository = userRepository;
    	}
    	
    	public void Work()
    	{
    		var cont = true;
    		do
    		{   
    			//code here                
    			using (_userRepository)
    			{
    				_userRepository.Save(new User());
    				cont = false;
    			}
    	
    		} while (cont);
    	}
    }
    
    public interface IRepository<T> : IDisposable
    {
    	void Save(T model);
    }
    
    public class Repository<T> : IRepository<T>
    {
    	public void Dispose() { }
    	public void Save(T model) {}
    }
    
    public class User {}
