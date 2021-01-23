	public class MainController : Controller
	{
		private IUrlHelperFactory urlHelperFactory { get; }
		private IActionContextAccessor accessor { get; }
		public MainController(IUrlHelperFactory urlHelper, IActionContextAccessor accessor)
		{
			this.urlHelperFactory = urlHelper;
			this.accessor = accessor;
		}
		[HttpGet]
		public IActionResult Index()
		{
			ActionContext context = this.accessor.ActionContext;
			IUrlHelper urlHelper = this.urlHelperFactory.GetUrlHelper(context);
            //Use urlHelper here
			return this.Ok();
		}
	}
