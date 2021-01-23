    public class SqlConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            try
            {
                string connectionString = $"Data Source={Program.servername};Initial Catalog={Program.database};User ID={Program.mlogin};password={Program.password};";
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            } catch (SqlException se) when (se.Number == 18456) 
            {
                MessageBox.Show("Your password is invalid. Try to login again.");
                Environment.Exit(0);
            }
        }
    }
    // Everywhere in your code
    SqlConnectionFactory.CreateConnection().
