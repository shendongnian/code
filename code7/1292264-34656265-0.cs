    public static class ConnectionFactory{
        private static string connectionString = "connection string"; //You could get this from config file as other answers suggest.
        public static SqlConnection GetConnection(){
             return new SqlConnection(connectionString);
        }
    }
