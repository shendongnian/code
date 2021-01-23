	public interface IMonitorFactory
	{
		void RegisterContainerAndTypes(Container container);
		IMonitor Create(Guid systemId, Dictionary<string,string> settings);
	}
	public class DevLinkMonitorFactory : IMonitorFactory
	{
		private Container _container;
		
		public void RegisterContainerAndTypes(Container container)
		{
			_container = container;
			// register all container stuff this plugin uses
			container.Register<IDevLinkTransport, WcfTransport>();
			// we could do other stuff such as register simple injector decorators
			// if we want to shift cross-cutting loggin concerns to a wrapper etc etc
		}
		public IMonitor Create(Guid systemId, Dictionary<string,string> settings)
		{			
			// logger has already been registered by the main framework
			var logger = _container.GetInstance<ILogger>();
			// transport was registered previously
			var transport = _container.GetInstance<IDevLinkTransport>();
			var username = settings["Username"];
			var password = settings["Password"];
			// proxy creation and wire-up dependencies manually for object being created
			return new DevLinkMonitor(systemId, logger, transport, username, password);
		}
	}
