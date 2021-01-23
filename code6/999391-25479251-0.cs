    public class Connection
    {
        SqlConnection conn;
        SqlCommand cmd;
    
        public void connclose()
        {
            conn.Close();
        }
    
        public Connection()
        {
            // initializing global variables
            conn = new SqlConnection(@"server=ADMIN-PC;database=sample;Integrated security=true");
            cmd = null;
        }
    
        public void nonquery(string qry)
        {
            conn.Open();
            cmd = new SqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
