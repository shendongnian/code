    public class SimpleClass
    {
        public static void InvokeSql(Action<SqlConnection> func)
        {
            if (func == null)
            {
                throw new NullReferenceException("func");
            }
            using (SqlConnection connection = new SqlConnection("Data ..."))
            {
                connection.Open();
                func(connection);
            }
        }
    }
