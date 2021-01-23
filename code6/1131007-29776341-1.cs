	public class MvcController : Controller
	{
		private IService _service;
		public MvcController(IService service) // depending on abstraction
		{
			_service = service;
		}
	}
