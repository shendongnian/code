    [RoutePrefix("api/member")]
    public class MemberController : ApiController {
    
        //eg POST api/member/updateprofile
        [HttpPost]
        [Route("updateprofile")]
        public HttpResponseMessage updateProfile() {
            var result = new HttpResponseMessage(HttpStatusCode.OK);
    
            var httpRequest = HttpContext.Current.Request;
    
            return result;
        }
    }
