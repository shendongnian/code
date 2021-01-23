    /// <summary>
    /// Helper class to builk insert data into a table
    /// </summary>
    public struct MySQLFieldDefinition
    {
        public MySQLFieldDefinition(string field, MySqlDbType type) : this()
        {
            FieldName = field;
            ParameterType = type;
        }
        public string FieldName { get; private set; }
        public MySqlDbType ParameterType { get; private set; }
    }
    public class MySQLBulkInsertData : List<object[]>
    {
        public MySQLBulkInsertData(params MySQLFieldDefinition[] fieldnames)
        {
            Fields = fieldnames;
        }
        public MySQLFieldDefinition[] Fields { get; private set; }
    }
