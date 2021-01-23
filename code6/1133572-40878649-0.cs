       public static async Task<IEnumerable<object>>  public static async Task<IEnumerable<object>> GetAnonymousResults(IUnitOfWork unitOfWork, string spName,
            SqlParameter[] outParameters, params SqlParameter[] parameters)
        {
            //errrm, whatever, all you need is your context here. 
            var context = unitOfWork as DbContext;
            DbCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            command.Connection = context.Database.Connection;
            command.Parameters.AddRange(parameters);
            //Forget this if you don't have any out parameters
            command.Parameters.AddRange(outParameters);
            try
            {
                command.Connection.Open();
                var reader = await command.ExecuteReaderAsync();
                return reader.ToObjectList();
            }
            finally
            {
                command.Connection.Close();
            }
        }
    
            public static List<object> ToObjectList(this IDataReader dataReader, bool ignoreUnmappedColumns = true)
            {
                var list = new List<object>();
                while (dataReader.Read())
                {
                    IEnumerable<string> columnsName = dataReader.GetColumnNames();
                    var obj = new ExpandoObject() as IDictionary<string, object>;
    
                    foreach (var columnName in columnsName)
                    {
                        obj.Add(columnName, dataReader[columnName]);
                    }
                    var expando = (ExpandoObject)obj;
    
                    list.Add(expando);
                }
    
                return list;
            }
    
       public static IEnumerable<string> GetColumnNames(this IDataReader reader)
            {
                var schemaTable = reader.GetSchemaTable();
                return schemaTable == null
                    ? Enumerable.Empty<string>()
                    : schemaTable.Rows.OfType<DataRow>().Select(row => row["ColumnName"].ToString());
            }
