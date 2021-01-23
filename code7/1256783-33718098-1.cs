    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.EntityClient;
    namespace EF6_SQLCompact_CleanTest_000
    {
      public class EFTest
      {
        public void Test()
        {
          try
          {
            // Add an event handler for DbConfiguration.Loaded, which adds our dependency 
            // resolver class to the chain of resolvers.
            System.Data.Entity.DbConfiguration.Loaded += (_, a) => {
              a.AddDependencyResolver(new MyDependencyResolver(), true);
            };
            // Define the provider connection string, specifying the SQL Server Compact 3.5 filename.
            String FileName = @"f:\DotNetTestProjects\2015\CS\SQLCompact35DllTest\SQLCompact35DllTest\ProjectTemplate.sdf";
            String ConnectionString = String.Format("Data Source={0}", FileName);
            // Create the entity framework connection string, specifying the model,
            // the provider and the provider connection string.
            var builder = new EntityConnectionStringBuilder();
            builder.Metadata = @"res://*/ProjectTemplate.csdl|res://*/ProjectTemplate.ssdl|res://*/ProjectTemplate.msl";
            builder.Provider = "System.Data.SqlServerCe.3.5";
            builder.ProviderConnectionString = ConnectionString;
            // Create the entity framework kontext
            Entities Context = new Entities(builder.ToString());
            // Do a trivial query as a test.
            int i = Context.Languages.Count();
            MessageBox.Show(i.ToString());
          }
          catch (Exception e)
          {
            MessageBox.Show(e.Message);
          }
        }
      }
      // Define an additional constructor for the Entities class, so that we can 
      // pass the connection string into the base class DbContext.
      public partial class Entities : DbContext
      {
        public Entities(String ConnectionString)
          : base(ConnectionString)
        {
        }
      }
      class MyDependencyResolver : System.Data.Entity.Infrastructure.DependencyResolution.IDbDependencyResolver
      {
        public object GetService(Type type, object key)
        {
          // Output the service attempting to be resolved along with it's key 
          System.Diagnostics.Debug.WriteLine(string.Format("MyDependencyResolver.GetService({0}, {1})", type.Name, key == null ? "" : key.ToString()));
          if ((type == typeof(System.Data.Common.DbProviderFactory))
               && (key != null)
               && ((string)(key) == "System.Data.SqlServerCe.3.5"))
          {
            return System.Data.SqlServerCe.SqlCeProviderFactory.Instance ;
          }
          else if ((type == typeof(System.Data.Entity.Core.Common.DbProviderServices))
                    && (key != null)
                    && ((string)(key) == "System.Data.SqlServerCe.3.5"))
          {
            return System.Data.Entity.SqlServerCompact.Legacy.SqlCeProviderServices.Instance ;
          }
          else if ((type == typeof(System.Data.Entity.Infrastructure.IProviderInvariantName))
                    && (key is System.Data.SqlServerCe.SqlCeProviderFactory))
          {
            return new MyProviderInvariantName();
          }
          return null;
        }
        public IEnumerable<object> GetServices(Type type, object key)
        {
          return new object[] { GetService(type, key) }.ToList().Where(o => o != null);
        }
      }
      // Implement IProviderInvariantName so that we can return an object when
      // requested in GetService()
      class MyProviderInvariantName : IProviderInvariantName
      {
        public string Name
        {
          get { return "System.Data.SqlServerCe.3.5"; }
        }
      }
    }
