    public class UserController : Controller
    {
        tbl_Users objUser = new tbl_Users();
        IUserRepository Repository; 
    
        public UserController(IUserRepository userRepository)
        {
             Repository = userRepository;
        }   
    
        ...etc    
    }
    
