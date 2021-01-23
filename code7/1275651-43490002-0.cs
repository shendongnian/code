    public class UserController : ApiController
    {
        [Route("api/user")]
        [SwaggerOperation(Tags = new[] { "User" })]
        IHttpActionResult GetUser() { ... }
    }
    public class ResumeController : ApiController
    {
        [Route("api/user/resumes")]
        [SwaggerOperation(Tags = new[] { "User" })]
        IHttpActionResult GetResumes() { ... }
    }
