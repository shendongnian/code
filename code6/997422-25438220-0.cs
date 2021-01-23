    [System.Web.Mvc.Authorize]
    public class ProfileController : Controller
    {
        private readonly IMyClient client;
    
        public ProfileController(Func<IMyClient> clientFactory)
        {
            client = clientFactory.Invoke();
        }
    
    }
