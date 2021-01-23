	public sealed class CompositionRoot : DefaultControllerFactory
	{
		private static string connectionString = 
			ConfigurationManager.ConnectionStrings["app"].ConnectionString;
		protected override IController GetControllerInstance(RequestContext _, Type type) {
			if (type == typeof(UsersController))
				return new UsersController(new UsersRepository());
			// [other controllers here]
			return base.GetControllerInstance(_, type);
		}
	}
