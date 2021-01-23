	public class ConnectionStringBuilder
	{
		public static string Construct()
		{
			var newConnStringBuilder = new SqlConnectionStringBuilder
			{
				UserID = "user",
				Password = "pass",
				InitialCatalog = "databaseName",
				DataSource = "serverName"
			};
			var entityConnectionBuilder = new EntityConnectionStringBuilder
			{
				Provider = "System.Data.SqlClient",
				ProviderConnectionString = newConnStringBuilder.ToString(),
				Metadata = @"res://*/TestModel.csdl|
								res://*/TestModel.ssdl|
								res://*/TestModel.msl"
			};
			return entityConnectionBuilder.ToString();
		}
	}
