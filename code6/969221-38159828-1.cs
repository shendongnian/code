    public class ProcessDataset
    {
        // Takes a Sql string
        public static DataTable ReadTable(string sql)
        {
           var returnValue = new DataTable();
           // checks if there is a sql string provided
           if (!String.IsNullOrEmpty(sql)) 
           {
                
                var conn = new SqlConnection(ConnectionString._connectionString);
                conn.Open();
                var command = new SqlCommand(sql, conn);
                // rest of code
           }
           else 
           {
               // show message to user
               MessageBox.Show(" no sql command ");
           }
           return returnValue;
        }
     }
