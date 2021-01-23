    public class BaseApiController : ApiController
    { 
        private ApplicationUserManager _appUserManager = null;
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _appUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
    }
