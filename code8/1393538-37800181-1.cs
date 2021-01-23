        public class TideUploadsController : Controller
            {
    
                public TideUploadsController(IUserRepository userRepository){
                  // constructor injection
                  // assign your user repository to a local variable outside of the constructor scope something like _userRepository
                }
    
                [HttpGet]
                public ActionResult Index()
                {            
                    return View(_userRepository.GetUserById(1)); 
                    // let's assume your variable's name is _userRepository
                }
        
                /* further CRUD ActionResults not shown */
        
            }
        }
