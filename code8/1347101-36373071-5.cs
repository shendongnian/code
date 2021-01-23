     [RoutePrefix("api/my")]
     public class MyController : ApiController
     {
        [Route("save")]
        [HttpPost]
        public HttpResponseMessage Post(TaskList tasklistModel)
        {
           //Your code here
        }
     }
