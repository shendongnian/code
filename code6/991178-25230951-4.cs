	public class NinjectDependencyResolver : IDependencyResolver
	{
		private IKernel iKernel;
		public NinjectDependencyResolver(IKernel kernel)
		{
			iKernel = kernel;
			AddBindigs();
		}
		public object GetService(Type serviceType)
		{
			return iKernel.TryGet(serviceType);
		}
		public IEnumerable<object> GetServices(Type serviceType)
		{
			return iKernel.GetAll(serviceType);
		}
		private void AddBindigs()
		{
             //Add your bindings here....
			iKernel.Bind<IProductRepository>().To<EFProductRepository>();
			
			iKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().
				WithConstructorArgument("settings", emailSettings);
        }
	}
