	public class SignalRDependencyResolver : DefaultDependencyResolver
	{
		public SignalRDependencyResolver(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}
		public override object GetService(Type serviceType)
		{
			return _serviceProvider.GetService(serviceType) ?? base.GetService(serviceType);
		}
		public override IEnumerable<object> GetServices(Type serviceType)
		{
			var @this = (IEnumerable<object>) _serviceProvider.GetService(typeof (IEnumerable<>).MakeGenericType(serviceType));
			var @base = base.GetServices(serviceType);
			return @this == null ? @base : @base == null ? @this : @this.Concat(@base);
		}
		private readonly IServiceProvider _serviceProvider;
	}
    public class SignalRHubDispatcher : HubDispatcher
	{
		public SignalRHubDispatcher(Container container, HubConfiguration configuration) : base(configuration)
		{
			_container = container;
		}
		protected override Task OnConnected(IRequest request, string connectionId)
		{
			return Invoke(() => base.OnConnected(request, connectionId));
		}
		protected override Task OnReceived(IRequest request, string connectionId, string data)
		{
			return Invoke(() => base.OnReceived(request, connectionId, data));
		}
		protected override Task OnDisconnected(IRequest request, string connectionId, bool stopCalled)
		{
			return Invoke(() => base.OnDisconnected(request, connectionId, stopCalled));
		}
		protected override Task OnReconnected(IRequest request, string connectionId)
		{
			return Invoke(() => base.OnReconnected(request, connectionId));
		}
		private async Task Invoke(Func<Task> method)
		{
			using (_container.BeginExecutionContextScope())
				await method();
		}
		private readonly Container _container;
	}
	
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var container = new Container();
			container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
			
			container.Register<DbContext, MyDbContext>(Lifestyle.Scoped);
			container.Register<ISampleRepository, SampleRepository>(Lifestyle.Scoped);
			// if you want to use the same container in WebApi don't forget to add
			app.Use(async (context, next) => {
				using (container.BeginExecutionContextScope())
					await next();
			});
			// ... configure web api 
			
			var config = new HubConfiguration
			{
				Resolver = new SignalRDependencyResolver(container)
			}
			
			// ... configure the rest of SignalR
			// pass SignalRHubDispatcher
			app.MapSignalR<SignalRHubDispatcher>("/signalr", config);
		}
	}
