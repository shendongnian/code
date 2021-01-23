    public class UsersController : ApiController
        {
     
            // GET api/values/5
            public string GetUsersByRole(string role)
            {
                return "Role: " + role;
            }
    
            public string GetUsersByDivision(string division)
            {
                return "Division: " + division;
            }
        }
