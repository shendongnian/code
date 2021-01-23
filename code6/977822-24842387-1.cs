    public class UsersController : ApiController
    {
        private readonly IUserService _userService;
    
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
    
        // GET: api/Users
        public IEnumerable<string> Get()
        {
            return _userService.GetUsers();
        }
    }
