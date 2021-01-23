	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private readonly IKernel kernel;
		public NinjectControllerFactory(IKernel kernel)
		{
			this.kernel = kernel;
		}
		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			return controllerType == null
					   ? null
					   : (IController) ninjectKernel.Get(controllerType);
		}
	}
