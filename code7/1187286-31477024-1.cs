    public class MsSqlDatabaseHelpers
    {
        public static DataTable GetDataTable(SqlCommand command, string connectionString)
        {
           DataTable dt = new DataTable();
           using (var connection = new SqlConnection(connectionString))
           {
               command.Connection = connection;
    		   connection.Open();
    		   dt.Load(command.ExecuteReader());
    	   }
           return dt;
        }
    }
