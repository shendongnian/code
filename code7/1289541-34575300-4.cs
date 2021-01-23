    public class Database : IDatabase, IDisposeable
    {
    	private Entities db;
    	public Database()
    	{
    		db = new Entities()
    	}
    	
    ... some other methods ...
        public bool VerifyUser(string verificationHash)
        {
    		var userToVerify = db.VerifyUser(verificationHash);
    		int count = userToVerify.Count();
    		if (count == 1)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}        
        }
    	
    	public void Dispose()
    	{
    		db.Dispose()
    	}
    }
