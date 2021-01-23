    [RoutePrefix("api/student")]
    public class StudentController : ApiController {
        // POST api/student
        [HttpPost]
        [Route("")]
        public async Task<string> Post() {
            var content = await Request.Content.ReadAsStringAsync();
            return content;
        }
    }
