    public class DatabaseFieldSection : ConfigurationSection
    {
        public static DatabaseFieldSection GetConfig()
        {
            return (DatabaseFieldSection)System.Configuration.ConfigurationManager.GetSection("DatabaseConfig") ?? new DatabaseFieldSection();
        }
        [System.Configuration.ConfigurationProperty("DatabaseFields")]
        [ConfigurationCollection(typeof(DatabaseFieldCollection), AddItemName = "add")]
        public DatabaseFieldCollection DatabaseFields
        {
            get
            {
                object o = this["DatabaseFields"];
                return o as DatabaseFieldCollection;
            }
        }
    }
