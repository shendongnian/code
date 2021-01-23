    class Program
    {
        static IEnumerable<SqlDataReader> InteractionGetData(string query)
        {
            using (var connection = new SqlConnection(@"Data Source=localhost;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader;
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            foreach (var reader in InteractionGetData("SELECT DISTINCT ProductName FROM Products"))
            {
                Console.WriteLine(reader.GetString(reader.GetOrdinal("ProductName")));
            }
        }
    }
