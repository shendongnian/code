    class TableNameInsertionResolver : DefaultContractResolver
    {
        private Dictionary<string, string> tableNames;
        public TableNameInsertionResolver(Dictionary<string, string> tableNames)
        {
            this.tableNames = tableNames;
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            // If there is an associated table name for this type, 
            // add a virtual property that will return the name
            string tableName;
            if (tableNames.TryGetValue(type.FullName, out tableName))
            {
                props.Insert(0, new JsonProperty
                {
                    DeclaringType = type,
                    PropertyType = typeof(string),
                    PropertyName = "__tableName",
                    ValueProvider = new TableNameValueProvider(tableName),
                    Readable = true,
                    Writable = false
                });
            }
            return props;
        }
        class TableNameValueProvider : IValueProvider
        {
            private string tableName;
            public TableNameValueProvider(string tableName)
            {
                this.tableName = tableName;
            }
            public object GetValue(object target)
            {
                return tableName;
            }
            public void SetValue(object target, object value)
            {
                throw new NotImplementedException();
            }
        }
    }
