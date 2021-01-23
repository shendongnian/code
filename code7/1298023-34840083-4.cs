    public class UserController : Controller
    {
    	private readonly IUserBusiness userBusiness;
    	
		//Controller receives a UserBusinnes instance via DI
    	public UserController(IUserBusiness userBusiness)
    	{
    		this.userBusiness = userBusiness;
    	}
    	
    	public ActionResult GetDetail(int userId)
    	{
			//Call your "repository" to get user data
    		var userDetail = userBusiness.GetUserDetail(userId);
    		
    		//more logic here
    	}
    }
