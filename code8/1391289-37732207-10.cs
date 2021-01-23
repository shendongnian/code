    public class StudentsController : ApiController {
        // POST api/students
        [HttpPost]
        public IHttpActionResult Post(Student student) {
            db.Students.Add(student);
            db.SaveChanges();
            return Ok();
        }
    }
