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
        // POST api/student/bodyexample
        [HttpPost]
        [Route("bodyexample")]
        public async Task<Student> Post2([FromBody]FirstName, [FromBody] LastName) {
            var content = new Student { FirstName = FirstName, LastName = LastName };
            return content;
        }
    }
