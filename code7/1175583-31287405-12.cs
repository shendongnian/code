	public interface IModule
	{
		public int Order { get; }
		public string Name { get; }
		public Version Version { get; }
		IEnumerable<ServiceDescriptor> GetServices();
	}
	public interface IModuleProvider
	{
		IEnumerable<IModule> GetModules();
	}
