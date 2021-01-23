    public static class Helper
    {
        public static List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var context = new WannaSportContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = query;
                    command.CommandType = CommandType.Text;
                    context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        var entities = new List<T>();
                        while (result.Read())
                        {
                            entities.Add(map(result));
                        }
                        return entities;
                    }
                }
            }
        }
