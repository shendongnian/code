    public abstract class BaseController<T> : Controller where T :class
	{
		public IServiceClient ServiceClient { get; set; }
		
		public BaseController(IServiceClient serviceClient)
		{
			ServiceClient = serviceClient;
		}
	}
