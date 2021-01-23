    public class DivisionsController : ApiController
    {
        [Route("/Divisions/{id}")]
        [HttpGet]
        public Division GetDivision(int id)
        {
            return // your code here
        }
        [Route("/Divisions/{id}/Dept")]
        [HttpGet]
        public IEnumerable<Deparment> GetDepartments(int id)
        {
            return // your code here
        }
        Route("/Divisions/{id}/Dept/{deptId}")]
        [HttpGet]
        public Deparment GetDepartments(int id, int deptId)
        {
            return // your code here
        }
    }
