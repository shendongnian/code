	public partial class MyInstanceProvider : IInstanceProvider, IContractBehavior
	{
		private readonly IContainer container;
		private readonly Type serviceType;
		
		public MyInstanceProvider(IContainer container, Type serviceType)
		{
			if (container == null)
				throw new ArgumentNullException("container");
				
			this.container = container;
			this.serviceType = serviceType;
		}
		
		public object GetInstance(InstanceContext instanceContext, Message message)
		{
			return this.GetInstance(instanceContext);
		}
		
		public object GetInstance(InstanceContext instanceContext)
		{
			return this.container.GetInstance(this.serviceType);
		}
		
		public void ReleaseInstance(InstanceContext instanceContext, object instance)
		{
			// Allow the lifetime management behavior of StructureMap to release dependencies
		}
		
		public void ApplyDispatchBehavior(
			ContractDescription contractDescription, ServiceEndpoint endpoint,
			DispatchRuntime dispatchRuntime)
		{
			dispatchRuntime.InstanceProvider = this;
		}
	}
