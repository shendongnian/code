		using System.Linq;
		namespace NorthWin
		{
			public class DAL
			{
				string ConnectionString = @"metadata=res://*/NorthWind.csdl|res://*/NorthWind.ssdl|res://*/NorthWind.msl;provider=System.Data.SqlClient;provider connection string='data source=myserver;initial catalog=Northwind;persist security info=True;user id=xxx;password=yyy;MultipleActiveResultSets=True;App=EntityFramework';";
		
       public DAL (string connString)
        {
          ConnectionString =connString;
        }		
        public int GetCustomerCount()
				{
					var n = 0;
                // call ye new overload constructor
					using (var ctx = new NorthwindEntities(ConnectionString))
					{
						n = ctx.Customers.Count();
					}
					return n;
				}
			}
		}
