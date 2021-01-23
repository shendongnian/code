	public class MyServiceHost : ServiceHost
	{
		public MyServiceHost(IContainer container, Type serviceType, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses)
		{
			if (container == null)
				throw new ArgumentNullException("container");
			var contracts = this.ImplementedContracts.Values;
			foreach (var c in contracts)
			{
				c.Behaviors.Add(new MyInstanceProvider(container, serviceType));
			}
		}
	}
