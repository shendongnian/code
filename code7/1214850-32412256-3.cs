    namespace SqliteEFNoConfig
    {
        using System.Configuration;
        using System.Data;
        using System.Data.Common;
        using System.Data.Entity;
        using System.Data.Entity.Core.Common;
        using System.Data.SQLite;
        using System.Data.SQLite.EF6;
        using System.Linq;
        internal class Program
        {
            private static void Main()
            {
                // EF manages the connection via the DbContext instantiation
                // connection string is set in config
                // Use this code if you want to use a config file
                // with only the connection string
                //using (var model = new Model1())
                //{
                //    var dbSetProperty = model.dbSetProperty.ToList();
                //}
                // Alternative method: 
                // Use this code if you don't want to use a config file
                // You will also need to use the override constructor shown below,
                // in your EF Model class
                var connectionString = @"data source = {PathToSqliteDB}";
                using (var connection = new SQLiteConnection(connectionString))
                {
                    using (var model = new Model1(connection))
                    {
                        var dbSetProperty = model.dbSetProperty.ToList();
                    }
                }
            }
        }
   
        class SqliteDbConfiguration : DbConfiguration
        {
            public SqliteDbConfiguration()
            {
                string assemblyName = typeof (SQLiteProviderFactory).Assembly.GetName().Name;
                RegisterDbProviderFactories(assemblyName );
                SetProviderFactory(assemblyName, SQLiteProviderFactory.Instance);
                SetProviderServices(assemblyName,
                    (DbProviderServices) SQLiteProviderFactory.Instance.GetService(
                        typeof (DbProviderServices)));
            }
            static void RegisterDbProviderFactories(string assemblyName)
            {
                var dataSet = ConfigurationManager.GetSection("system.data") as DataSet;
                if (dataSet != null)
                {
                    var dbProviderFactoriesDataTable = dataSet.Tables.OfType<DataTable>()
                        .First(x => x.TableName == typeof (DbProviderFactories).Name);
                    var dataRow = dbProviderFactoriesDataTable.Rows.OfType<DataRow>()
                        .FirstOrDefault(x => x.ItemArray[2].ToString() == assemblyName);
                    if (dataRow != null)
                        dbProviderFactoriesDataTable.Rows.Remove(dataRow);
                    dbProviderFactoriesDataTable.Rows.Add(
                        "SQLite Data Provider (Entity Framework 6)",
                        ".NET Framework Data Provider for SQLite (Entity Framework 6)",
                        assemblyName,
                        typeof (SQLiteProviderFactory).AssemblyQualifiedName
                        );
                }
            }
        }
    }
    
