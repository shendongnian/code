    public static class StoreConfigurationExtension
    {
        public static T GetStoreConfiguration<T>(this DbContext db, string key)
        {
            var sc = db.Set<StoreConfiguration>().Find(key);
            if (sc == null) return default(T);
            var value = sc.Value;
            var tc = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                var convertedValue = (T)tc.ConvertFromString(value);
                return convertedValue;
            }
            catch (NotSupportedException)
            {
                return default(T);
            }
        }
        public static void SetStoreConfiguration(this DbContext db, string key, object value)
        {
            var sc = db.Set<StoreConfiguration>().Find(key);
            if (sc == null)
            {
                sc = new StoreConfiguration { Key = key };
                db.Set<StoreConfiguration>().Add(sc);
            }
            sc.Value = value == null ? null : value.ToString();
        }
    }
