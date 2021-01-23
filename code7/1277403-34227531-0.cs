    public class Add : ConfigurationElement
    {
        [ConfigurationProperty("Key", IsKey = true, IsRequired = true)]
        public string Key
        {
            get { return (string)base["Key"]; }
        }
        [ConfigurationProperty("TableName", IsKey = false, IsRequired = true)]
        public string TableName
        {
            get { return (string)base["TableName"]; }
        }
        [ConfigurationProperty("ColumnName", IsKey = false, IsRequired = true)]
        public string ColumnName
        {
            get { return (string)base["ColumnName"]; }
        }
        [ConfigurationProperty("FieldType", IsKey = false, IsRequired = true)]
        public string FieldType
        {
            get { return (string)base["FieldType"]; }
        }
    }
