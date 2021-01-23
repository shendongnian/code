    public class EmployeeController : ApiController
        {
            static EmpRepository repository = new EmpRepository();
        
            public string GetData() {
                var re = repository.GetData();
                return re;
            }
        
        }
