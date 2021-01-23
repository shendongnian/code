	public class DefaultLoggerModule : ModuleBase
	{
		public override int Order { get { return ModuleOrder.Level3; } }
		public override IEnumerable<ServiceDescriptor> GetServices()
		{
			yield return ServiceDescriptor.Instance<ILoggerFactory>(new DefaultLoggerFactory());
		}
	}
