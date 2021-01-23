    public class EmployeeController : ApiController
    {
        // GET api/employee
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    
        // GET api/employee/5
        public string Get(int id)
        {
            return "value";
        }
    }
