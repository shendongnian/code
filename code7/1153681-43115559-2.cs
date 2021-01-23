    internal static class DbConnectionExtensions
    {
        public static void CreateTableIfNotExists<T>(this IDbConnection connection, string tableName)
        {
            var columns = GetColumnsForType<T>();
            var fields = string.Join(", ", columns.Select(x => $"[{x.Item1}] TEXT"));
            var sql = $"CREATE TABLE IF NOT EXISTS [{tableName}] ({fields})";
            ExecuteNonQuery(sql, connection);
        }
        public static void Insert<T>(this IDbConnection connection, string tableName, T item)
        {
            var properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(x => x.Name, y => y.GetValue(item, null));
            var fields = string.Join(", ", properties.Select(x => $"[{x.Key}]"));
            var values = string.Join(", ", properties.Select(x => EnsureSqlSafe(x.Value)));
            var sql = $"INSERT INTO [{tableName}] ({fields}) VALUES ({values})";
            ExecuteNonQuery(sql, connection);
        }
        public static void InsertAll<T>(this IDbConnection connection, string tableName, IEnumerable<T> items)
        {
            foreach (var item in items)
                Insert(connection, tableName, item);
        }
        private static IEnumerable<Tuple<string, Type>> GetColumnsForType<T>()
        {
            return from pinfo in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                let attribute = pinfo.GetCustomAttribute<DbColumnAttribute>()
                let columnName = attribute?.Name ?? pinfo.Name
                select new Tuple<string, Type>(columnName, pinfo.PropertyType);
        }
        private static void ExecuteNonQuery(string commandText, IDbConnection connection)
        {
            using (var com = connection.CreateCommand())
            {
                com.CommandText = commandText;
                com.ExecuteNonQuery();
            }
        }
        private static string EnsureSqlSafe(object value)
        {
            return IsNumber(value)
                ? $"{value}"
                : $"'{value}'";
        }
        private static bool IsNumber(object value)
        {
            var s = value as string ?? "";
            // Make sure strings with padded 0's are not passed to the TryParse method.
            if (s.Length > 1 && s.StartsWith("0"))
                return false;
            return long.TryParse(s, out long l);
        }
    }
