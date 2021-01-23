    class connect_class
    {
        public string sql_string;
        public string str_con;
        public System.Data.SqlClient.SqlDataAdapter d_a;
        public System.Data.DataSet d_s;
        public System.Data.SqlClient.SqlConnection con;
    
    
        public connect_class()
        {
            // Nothing needed here,
            // Of course before calling MyDataSet you need to set the public properties
            // for the connection string and sql command text.
        }
    
        public System.Data.DataSet MyDataSet()
        {
            DataSet ds = new System.Data.DataSet();
            using(SqlConnection cn = new SqlConnection(this.str_con))
            using(SqlDataAdapter da = new SqlDataAdapter(sql_string, cn))
            {
                con.Open();
                da.Fill(ds);
                return ds;
            }
        }
    }
