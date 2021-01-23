     [RoutePrefix("api/user")]
        public class UserController : ApiController
        {
        [AllowAnonymous]
            [Route("")]
            public IHttpActionResult Get(string email = null)
            {        
                if (!string.IsNullOrEmpty(email))
                {
                    return Json(someUserProfileObject);
                }
                
                return Json(someListOfUserProfiles);
            }
        }
