    public static class SqlWrapper
    {
        private const string SqlConnectionString = "Server=localhost;Database=TTDS;User Id=sa;Password=sa;";
        private class NoResult { }
        public static List<T1> ExecuteQuery<T1>(string sql, object param = null, SqlConnection sqlConnection = null)
        {
            return ExecuteQuery<T1, NoResult, NoResult>(sql, param, sqlConnection).Item1;
        }
        public static Tuple<List<T1>, List<T2>> ExecuteQuery<T1, T2>(string sql, object param = null, SqlConnection sqlConnection = null)
        {
            var result = ExecuteQuery<T1, T2, NoResult>(sql, param, sqlConnection);
            return Tuple.Create(result.Item1, result.Item2);
        }
        public static Tuple<List<T1>, List<T2>, List<T3>> ExecuteQuery<T1, T2, T3>(string sql, object param = null, SqlConnection sqlConnection = null)
        {
            List<T1> list1;
            List<T2> list2 = null;
            List<T3> list3 = null;
            bool needsDisposed = false;
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(SqlConnectionString);
                sqlConnection.Open();
                needsDisposed = true;
            }
            try
            {
                using (var grid = sqlConnection.QueryMultiple(sql, param))
                {
                    list1 = grid.Read<T1>().ToList();
                    if (typeof(T2) != typeof(NoResult))
                    {
                        list2 = grid.Read<T2>().ToList();
                    }
                    if (typeof(T3) != typeof(NoResult))
                    {
                        list3 = grid.Read<T3>().ToList();
                    }
                    return Tuple.Create(list1, list2, list3);
                }
            }
            finally { if (needsDisposed) sqlConnection.Dispose(); }
        }
        public static void ExecuteNonQuery(SqlConnection sqlConnection, string sql, object param, int? timeout = null)
        {
            bool needsDisposed = false;
            if (sqlConnection == null)
            {
                sqlConnection = new SqlConnection(SqlConnectionString);
                sqlConnection.Open();
                needsDisposed = true;
            }
            try { sqlConnection.Execute(sql, param, commandTimeout: timeout); }
            finally { if (needsDisposed) sqlConnection.Dispose(); }
        }
    }
