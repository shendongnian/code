    [RoutePrefix("api/Employees")]
    public class CallsController : ApiController {
    
        //GET api/Employees/1/Calls
        //GET api/Employees/1/Calls/1
        [HttpGet]
        [Route("{id:int}/Calls/{callId:int?}")]
        public async Task<ApiResponse<object>> GetCall(int id, int? callId = null) {
            var testRetrieve = id;
            var testRetrieve2 = callId;
    
            throw new NotImplementedException();
        }
    
        //GET api/Employees/Calls
        [HttpGet]
        [Route("Calls")]
        public async Task<ApiResponse<object>> GetAllCalls() {
            throw new NotImplementedException();
        }
    }
