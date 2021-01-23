    public static class Entity7Extensions
    {
        public static IEnumerable<dynamic> ExecuteSqlCommandExtensionMethod(this DatabaseFacade database, string sql)
        {
            var connection = database.GetDbConnection();
            var command = connection.CreateCommand();
            command.CommandText = sql;
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var expandoObject = new ExpandoObject() as IDictionary<string, object>;
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        object propertyValue = reader.GetValue(i);
                        if (propertyValue is System.DBNull)
                            propertyValue = null;
                        expandoObject.Add(reader.GetName(i), propertyValue);
                    }
                    yield return expandoObject;
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
