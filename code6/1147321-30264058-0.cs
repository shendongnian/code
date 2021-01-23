    public abstract class BaseController : ApiController
	{
		protected override void Initialize(HttpControllerContext requestContext)
		{
			base.Initialize(requestContext);
			var culture = new CultureInfo("es");
			System.Threading.Thread.CurrentThread.CurrentCulture = culture;
			System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
		}
    }
