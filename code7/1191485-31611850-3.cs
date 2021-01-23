    public class YourDataClass
    {
        public void RunQuery(string query) //for add, update where you don't want to return anything, could add a second parameter to send in a List<SqlParameter> to add data.
        {
            using(OracleConnection conn= new OracleConnection(connString))
            using(OracleCommand cmd = new OracleCommand(query, conn))
            {
                conn.Open();
                //do your data transaction here
                
                cmd.ExecuteNonQuery();
            }
        }
    
        public DataTable GetData(string query) //for selecting data
        {
            using(OracleConnection conn= new OracleConnection(connString))
            using(OracleCommand cmd = new OracleCommand(query, conn))
            {
                conn.Open();
                //do your data transaction here
    
                dt.Add(cmd); //add data to data table or dataset
    
                return dt;
            }
        }
    }
