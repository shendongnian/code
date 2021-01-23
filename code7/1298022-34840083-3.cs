    public class UserBusiness : IUserBusiness
    {
    	private readonly IUserRepository userRepository;
    	
    	//CTOR receives a Repository instance via DI
    	public UserBusiness(IUserRepository userRepository)
    	{
    		this.userBusiness = userBusiness;
    	}
		
	    public User GetUserDetail(int userId)
	    {
			//Call repository to get User details
	    	return this.userRepository.GetUserDetail(userId);
	    }
    	
    	//other implementations here
    }
