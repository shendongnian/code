    [RoutePrefix("api/student")]
    public class StudentController : ApiController {
        // POST api/student
        [HttpPost]
        [Route("")]
        public async Task<Student> Post(Student content) {
            var FirstName = content.FirstName;
            var LastName = content.LastName;
            return content;
        }
    }
