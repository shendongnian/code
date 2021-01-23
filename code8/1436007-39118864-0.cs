    namespace EmployeeApi.Controllers
    {
        public class EmployeeDetailsController : ApiController
        {
            // GET api/employeedetails
    		[Route("api/employeedetails")]
    		[HttpGet]
            public IEnumerable<Employee> Get()
            {
    
            }
    		
    		// GET api/employeedetails/1
    		[Route("api/employeedetails/{id}")]
    		[HttpGet]
            public IEnumerable<Details> Get(int id)
            {
    
            }
    		
    		// GET api/employeedetails/id/teammember
    		[Route("api/employeedetails/id/teammember")]
    		[HttpGet]
            public IEnumerable<Team> GetTeamMember()
            {
    
            }
    		
    		// GET api/employeedetails/id/teammember/1
    		[Route("api/employeedetails/id/teammember/{tid}")]
    		[HttpGet]
            public IEnumerable<Details> GetTid(int tid)
            {
    
    
            }
    }
