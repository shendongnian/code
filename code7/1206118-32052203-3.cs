	public class ContainingClass
	{
		private static readonly string _databaseId;
		public static string DatabaseId { get { return _databaseId; } }
		
		static ContainingClass()
		{
			_databaseId = CloudConfigurationManager.GetSetting("database");
		}		
	}
