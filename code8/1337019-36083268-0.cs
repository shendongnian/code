    [Route("api/Authorization")]
    public class AuthorizationController : Controller
    {
        [HttpPost]
        public void Post([FromBody]AuthRequest authReq)
        {
            // authReq.Value should have your value in
        }
    }
