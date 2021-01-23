    public class DevelopersController : ApiController
    {
        private IService<USer> _userService;
        public DevelopersController(IService<USer> userService)
        {
            _userService= userService;
            _userService.SetIdentity(HttpContext.Current.Request.LogonUserIdentity.Name.ToString().Substring(4));
        }
