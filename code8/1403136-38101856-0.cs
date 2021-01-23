    [RoutePrefix("api/people")]
    public class MyController : ApiController
    {
        [HttpGet]
        [Route("messages")]
        public string GetMessages()
        {
          return "Get Messages Endpoint";
        }
        
        [HttpGet]
        [Route("employees")]
        public string GetEmployeeList()
        {
            return "Get Employees Endpoint";
        }
    }    
