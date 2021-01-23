    public class HomeController : ApiController
    {
        private readonly IModelFactory modelFactory;
        private readonly IServiceInterface serviceInterface;
        public HomeController(IModelFactory modelFactory, IServiceInterface serviceInterface) 
        {
            this.modelFactory = modelFactory;
            this.serviceInterface = serviceInterface;
        }
		
        // actions here
	}
