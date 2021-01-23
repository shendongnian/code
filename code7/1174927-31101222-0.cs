		public class NinjectDependencyResolver: IDependencyResolver {
			private readonly IKernel _kernel;
			public NinjectDependencyResolver(IKernel kernel) {
				_kernel = kernel;
				AddBindings();
			}
			public object GetService(Type serviceType) {
				return _kernel.TryGet(serviceType);
			}
			public IEnumerable<object> GetServices(Type serviceType) {
				return _kernel.GetAll(serviceType);
			}
			private void AddBindings() {
				// PULL YOUR BINDINGS HERE
				_kernel.Bind<Domain.Abstract.IQuizRepository>().To<Domain.Concrete.QuizRepository>();
			}
		}
