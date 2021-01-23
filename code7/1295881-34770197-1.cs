    public class MyPersonalORM
    {
        private string _connectionString;
        public MyPersonalORM(string connectionString)
        {
            _connectionString = connectionString;
        }
        public T Insert<T>(T insertPlz)
        {
            string tableName = typeof(T).Name;
            Dictionary<string, string> parameters = ...; // Use reflection to get the properties of T, then reflect into insertPlz to find the values.
            SqlParameter ... // Add each value in the dictionary to a parameter collection.
            // Do a typical Insert, but using Parameters.
        }
        public T Select<T>(T classForClauses)
        {
            string tableName = typeof(T).Name;
            Dictionary<string, string> parameters = ...; // Use reflection to get the properties of T, then reflect into insertPlz to find the values.
            SqlParameter ... // Add each value in the dictionary to a parameter collection.
            // Do a typical ADO Selct, but using Parameters for the clauses.
        }
    }
