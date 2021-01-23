    
    [Route("api/[controller]")]
    public class AccountsController : Controller {
        ....
        [HttpPost]
        [Route("~/api/token")]
        public async Task<JwtToken> Token([FromBody]Credentials credentials) {
            ...
        }
        ....
    }
