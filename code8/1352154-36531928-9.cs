    public class EmployeesController: ApiController {
    
        [HttpPost]
        [ResponseType(typeof(EmployeeDetailVm))]
        public IHttpActionResult Post(EmployeeDetailVm employees){...}
    
    }
