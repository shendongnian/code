    [RoutePrefix("/divisions/{id}")]
        public class DivisionsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public Division GetDivision(int id)
        {
            return // your code here
        }
        [Route("Dept")]
        [HttpGet]
        public IEnumerable<Deparment> GetDepartments(int id)
        {
            return // your code here
        }
        Route("Dept/{deptId}")]
        [HttpGet]
        public Deparment GetDepartments(int id, int deptId)
        {
            return // your code here
        }
    }
