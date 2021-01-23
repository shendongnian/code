    public class MyController : ApiController
    {
    
        private string GetUserId() {
            return User.Identity.GetUserId();
        }
    
        public IEnumerable<string> Get()
        {
            var userName = GetUserNameById(GetUserId());
            return new string[] { userName };
        }
    }
