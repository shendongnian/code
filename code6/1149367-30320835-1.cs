    public class UserController
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
             _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            // Simple example using IEnumerable<BLL.User> as the view model
            return View(_userRepository.GetAllUsers().ToList());
        }
    }
