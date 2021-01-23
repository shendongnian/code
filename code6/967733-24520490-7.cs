    [RoutePrefix("/divisions/{id}")]
    public class DivisionsController : ApiController
    {
        [Route]
        [HttpGet]
        public Division GetDivision(int id)
        {
            return // your code here
        }
        [Route("Dept")]
        [HttpGet]
        public IEnumerable<Department> GetDepartments(int id)
        {
            return // your code here
        }
        [Route("Dept/{deptId}")]
        [HttpGet]
        public Department GetDepartment(int id, int deptId)
        {
            return // your code here
        }
    }
