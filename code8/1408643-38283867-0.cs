    public class StudentController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            //studenti.Add(student);
            return CreatedAtRoute("StudentApi", new { ID = student.ID }, student);
        }
    }
