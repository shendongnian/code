	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start() {
			ControllerBuilder.Current.SetControllerFactory(new CompositionRoot());
			// the usual stuff here
		}
	}
