    
    public class UserController : ApiController
    {
        //Handle GET request to /api/{controller name}
        public List<User> Get()
        {
            return new List<User> { new User { Name = "Peter", Age = 41 } };
        }
    }
