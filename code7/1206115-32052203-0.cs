	public class ContainingClass
	{
		private readonly string _databaseId;
		public string DatabaseId { get { return _databaseId; } }
		
		public ContainingClass()
		{
			_databaseId = CloudConfigurationManager.GetSetting("database");
		}		
	}
