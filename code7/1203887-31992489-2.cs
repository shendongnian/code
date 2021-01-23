	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Http.Dependencies;
	using Ninject;
	using Ninject.Activation;
	using Ninject.Parameters;
	using Ninject.Syntax;
	internal class NinjectDependencyResolver : NinjectScope, IDependencyResolver
	{
		private readonly IKernel kernel;
		public NinjectDependencyResolver(IKernel kernel)
			: base(kernel)
		{
			if (kernel == null)
				throw new ArgumentNullException("kernel");
			this.kernel = kernel;
		}
		public IDependencyScope BeginScope()
		{
			return new NinjectScope(this.kernel.BeginBlock());
		}
	}
	internal class NinjectScope : IDependencyScope
	{
		protected IResolutionRoot resolutionRoot;
		public NinjectScope(IResolutionRoot kernel)
		{
			resolutionRoot = kernel;
		}
		public object GetService(Type serviceType)
		{
			IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
			return resolutionRoot.Resolve(request).SingleOrDefault();
		}
		public IEnumerable<object> GetServices(Type serviceType)
		{
			IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
			return resolutionRoot.Resolve(request).ToList();
		}
		public void Dispose()
		{
			IDisposable disposable = (IDisposable)resolutionRoot;
			if (disposable != null) disposable.Dispose();
			resolutionRoot = null;
		}
	}
