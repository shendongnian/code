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
        public IEnumerable<Department> GetDepartments(int id)
        {
            return // your code here
        }
        [Route("/Divisions/{id}/Dept/{deptId}")]
        [HttpGet]
        public Department GetDepartment(int id, int deptId)
        {
            return // your code here
        }
    }
