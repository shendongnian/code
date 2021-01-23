    public class UserRepository : IUserRepository
    {
    	public User GetUserDetail(int userId)
    	{
    		using(var _context = new RepoDBContext())
    		{
    			return _context.User.Where(m => m.id == userId).FirstOrDefault();
    		}		
    	}
    	
    	//other implementations here..
    }
