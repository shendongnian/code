    public class ProjectController : ApiController
    {
        [HttpPost]
        [MyAuthorize("DepartmentId","21")
        public void Edit(string applicationName)
        {
            // business logic
        }
    }
