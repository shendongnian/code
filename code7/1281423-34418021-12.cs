	public class DataServiceStrategy
	{
		private readonly IDataService[] dataServices;
		public DataServiceStrategy(IDataService[] dataServices)
		{
			if (dataServices == null)
				throw new ArgumentNullException("dataServices");
			this.dataServices = dataServices;
		}
		
		public void DoSomething(string provider)
		{
			var dataService = this.GetDataService(provider);
			dataService.DoSomething();
		}
		
		private IDataService GetDataService(string provider)
		{
			var dataService = this.dataServices.Where(ds => ds.AppliesTo(provider));
			if (dataService == null)
			{
                // Note: you could alternatively use a default provider here
                // by passing another parameter through the constructor
				throw new InvalidOperationException("Provider '" + provider + "' not registered.");
			}
			return dataService;
		}
	}
