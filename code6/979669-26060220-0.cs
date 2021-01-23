    Example:>
    
    using Microsoft.ApplicationServer.Caching;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    
    namespace SampleProvider
    {
      public class Provider : DataCacheStoreProvider
      {
        private readonly String dataCacheName;
        private readonly Dictionary<string, string> config;
    
        public Provider(string cacheName, Dictionary<string, string> config)
        {
          this.dataCacheName = cacheName; //Store the cache name for future use
          this.config = config;
        }
    
        public override DataCacheItem Read(DataCacheItemKey key)
        {
          Object retrievedValue = null;
          DataCacheItem cacheItem;
    
          retrievedValue = ReadFromDatabase(key.Key); //Your implemented method that searches in the backend store based
    
          if (retrievedValue == null)
            cacheItem = null;
          else
            cacheItem = DataCacheItemFactory.GetCacheItem(key, dataCacheName, retrievedValue, null);
          return cacheItem;
        }
        public override void Read(System.Collections.ObjectModel.ReadOnlyCollection<DataCacheItemKey> keys, IDictionary<DataCacheItemKey, DataCacheItem> items)
        {
          foreach (var key in keys)
          {
            items[key] = Read(key);
          }
        }
    
        public override void Delete(System.Collections.ObjectModel.Collection<DataCacheItemKey> keys) { }
    
        public override void Delete(DataCacheItemKey key) { }
    
        protected override void Dispose(bool disposing) { }
    
        public override void Write(IDictionary<DataCacheItemKey, DataCacheItem> items) { }
    
        public override void Write(DataCacheItem item) { }
    
    
        private string ReadFromDatabase(string key)
        {
          string value = string.Empty;
          object retrievedValue = null;
          using (SqlConnection connection = new SqlConnection(config["DBConnection"]))
          {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = string.Format("select Value from KeyValueStore where [Key] = '{0}'", key);
            cmd.Connection = connection;
            connection.Open();
            retrievedValue = cmd.ExecuteScalar();
            if (retrievedValue != null)
            {
              value = retrievedValue.ToString();
            }
          }
    
          return value;
        }
      }
    }
