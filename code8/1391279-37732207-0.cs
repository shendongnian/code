    public class StudentsController : ApiController {
        // POST api/students
        [HttpPost]
        public IHttpActionResult Post([FromBody]Student student) {
            db.Students.Add(student);
            db.SaveChanges();
            return Ok();
        }
    }
