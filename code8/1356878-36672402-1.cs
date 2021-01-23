    [Route("admin")]
    public class AdminController : Controller {
        // GET admin
        [Route("")]
        public IActionResult Index() {...}
    
        //GET admin/users
        [Route("users")]
        public IActionResult UserIndex() {...}
    
        //GET admin/users/details/1
        [Route("users/details/{id}")]
        public IActionResult UserDetails(string id) {...}
    
        //GET admin/roles 
        [Route("roles")]
        public IActionResult RoleIndex() {...}
    
        //GET admin/roles/details/1
        [Route("roles/details/{id}")]
        public IActionResult RoleDetails(string id) {...} 
    
    }
