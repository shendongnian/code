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
                //Build an SQL connection string
                SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
                {
                    DataSource = "SIPL35\\SQL2016".ToString(), // Server name
                    InitialCatalog = "Join8ShopDB",  //Database
                    UserID = "Sa",         //Username
                    Password = "Sa123!@#",  //Password
                };
                //Build an Entity Framework connection string
                EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
                {
                    Provider = "System.Data.SqlClient",
                    Metadata = "res://*/ShopModel.csdl|res://*/ShopModel.ssdl|res://*/ShopModel.msl",
                    ProviderConnectionString = @"data source=SIPL35\SQL2016;initial catalog=Join8ShopDB2;user id=Sa;password=Sa123!@#;"// sqlString.ToString()
                };
                return entityString.ConnectionString;
            }
