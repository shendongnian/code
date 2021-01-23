    public class Test
    {
    	private readonly ISaveRepository _userRepository;
    
    	public Test(ISaveRepository userRepository)
    	{
    		_userRepository = userRepository;
    	}
    	
    	public void Work()
    	{
    		var cont = true;
    		do
    		{              
    			using (_userRepository)
    			{
    				_userRepository.Save(new User());
    				cont = false;
    			}
    	
    		} while (cont);
    	}
    }
    
    public interface ISaveRepository : IDisposable
    {
    	void Save<T>(T model);
    }
    
    public class Repository<T> : ISaveRepository
    {
    	public void Dispose() { }
    	public void Save<TT>(TT model) {}
    }
    
    public class User {}
