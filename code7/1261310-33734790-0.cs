    public interface IConnectionFactory {
    	string ConnectionString();
    }
    public class MyDataAccessClass {
    
    	private readonly IConnectionFactory _connectionFactory
    	
    	public MyDataAccessClass(IConnectionFactory connectionFactory) {
    		_connectionFactory = connectionFactory;
    	}
    	
    	public void Whatever() {
    		var connectionString = _connectionFactory.ConnectionString();
    	}
    	
    }
   
