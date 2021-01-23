     public static void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader() ;
                while( reader.Read() ) {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                       Console.WriteLine( "Column name={0}, Value={1}", 
                            reader.GetName(i),
                            reader.GetValue(i) ); 
                    }
                }
            }
        }
