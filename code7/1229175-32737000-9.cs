	public class MyServiceHostFactory : ServiceHostFactory
	{
		private readonly IContainer container;
		
		public MyServiceHostFactory()
		{
			this.container = new Container(r => r.AddRegistry<MyRegistry>());
		}
		
		protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
	        return new MyServiceHost(this.container, serviceType, baseAddresses);
		}
	}
