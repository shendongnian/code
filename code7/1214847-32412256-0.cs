    namespace SqliteEFNoConfig
    {
        using System;
        using System.Configuration;
        using System.Data;
        using System.Data.Common;
        using System.Data.SQLite;
        using System.Data.SQLite.EF6;
        using System.IO;
        using System.Linq;
        using System.Reflection;
    
        internal class Program
        {
            private static void Main()
            {
                DbProviderSetup(true);
    
                // EF actually manages the connection via the DbContext instantiation
                using (var model = new Model1())
                {
                    var property = model.Property.ToList();
                }
    
                // Alternative method: 
    			// If you don't want to add the connection string to the config
                var connectionString = DbProviderSetup();
                using (var connection = new SQLiteConnection(connectionString))
                {
                    using (var model = new Model1(connection))
                    {
                        var property = model.Property.ToList();
                    }
                }
            }
    
            private static string DbProviderSetup(bool addConnectionStrings = false)
            {
                // DB Provider Factory section
                string assemblyName = typeof (SQLiteProviderFactory).Assembly.GetName().Name;
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
    
                var config = ConfigurationManager.OpenExeConfiguration(
    				Path.Combine(Assembly.GetExecutingAssembly().Location));
    
                // DB Provider Service section
                var entityFrameworkSection = Activator.CreateInstanceFrom("EntityFramework.dll",
                    "System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection").Unwrap()
    				as ConfigurationSection;
                if (entityFrameworkSection != null)
                {
                    entityFrameworkSection.SectionInformation.RequirePermission = false;
                    var providers = entityFrameworkSection.GetType().GetProperty("Providers");
                    var providerCollection = providers.GetValue(entityFrameworkSection, null);
                    providers.PropertyType.GetMethod("AddProvider").Invoke(providerCollection,
                        new object[]
                        {
                            assemblyName,
                            String.Format("{0}.SQLiteProviderServices, {0}", assemblyName)
                        });
                    if (config.Sections.Get("entityFramework") != null)
                        config.Sections.Remove("entityFramework");
    
                    config.Sections.Add("entityFramework", entityFrameworkSection);
                }
    
                // Connection string section
                var connectionStringSettings = new ConnectionStringSettings("Model1",
                    @"data source={PathToSqliteDB}", assemblyName);
    
                if (addConnectionStrings)
                {
                    config.ConnectionStrings.ConnectionStrings.Clear();
                    config.ConnectionStrings.ConnectionStrings.Add(connectionStringSettings);
                }
                else
                {
                    config.ConnectionStrings.ConnectionStrings.Remove(connectionStringSettings);
                }
    
                config.Save(ConfigurationSaveMode.Modified);
    
                // We need to refresh the manually added sections in order to trigger a re-read
                if (addConnectionStrings)
                    ConfigurationManager.RefreshSection("connectionStrings");
    
                ConfigurationManager.RefreshSection("entityFramework");
    
                return connectionStringSettings.ConnectionString;
            }
        }
    }
