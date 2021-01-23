    public class ExampleController : Controller
    {
		ISearchService _svc;
		public B2BHealthApiController(ISearchService s)
		{
			_svc = s;
		}
    }
