	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Data.Entity.Core.EntityClient;
	using System.Data.SqlClient;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	namespace Data
	{
		public class SingleConnection
		{
			private SingleConnection() { }
			private static SingleConnection _ConsString = null;
			private String _String = null;
			public static string ConString
			{
				get
				{
					if (_ConsString == null)
					{
						_ConsString = new SingleConnection { _String = SingleConnection.Connect() };
						return _ConsString._String;
					}
					else
						return _ConsString._String;
				}
			}
			public static string Connect()
			{
				string conString = ConfigurationManager.ConnectionStrings["YourConnectionStringsName"].ConnectionString;
				if (conString.ToLower().StartsWith("metadata="))
				{
					System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder efBuilder = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(conString);
					conString = efBuilder.ProviderConnectionString;
				}
				SqlConnectionStringBuilder cns = new SqlConnectionStringBuilder(conString);
				string dataSource = cns.DataSource;
				SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
				{
					DataSource = cns.DataSource, // Server name
					InitialCatalog = cns.InitialCatalog,  //Database
					UserID = cns.UserID,         //Username
					Password = cns.Password,  //Password,
					MultipleActiveResultSets = true,
					ApplicationName = "EntityFramework",
				};
				//Build an Entity Framework connection string
				EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
				{
					Provider = "System.Data.SqlClient",
					Metadata = "res://*",
					ProviderConnectionString = sqlString.ToString()
				};
				return entityString.ConnectionString;
			}
		}
	}
