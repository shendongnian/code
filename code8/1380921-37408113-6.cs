    private class SqlParamDefinition
    {
        public SqlParamDefinition(string name, SqlDbType dbType, object value)
        {
            this.Name = name;
            this.DbType = dbType;
            this.Value = value;
        }
        public string Name { get; }
        public SqlDbType DbType { get; }
        public object Value { get; }
    }
