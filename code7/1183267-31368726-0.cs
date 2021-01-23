    [Route("api/register/")]
    public class RegisterController : ApiController
    {
        public async Task<IHttpActionResult> Post(KeyValuePair<string, string> userData) 
        {
           // I never get inside here
        }
    }
