    class connect_class
    {
        public string sql_string;
        public string str_con;
        public System.Data.SqlClient.SqlDataAdapter d_a;
        public System.Data.DataSet d_s;
        public System.Data.SqlClient.SqlConnection con;
    
    
        public connect_class(string connectionString)
        {
            this.str_con = connectionString;
            con = new System.Data.SqlClient.SqlConnection(str_con);
            d_a = new System.Data.SqlClient.SqlDataAdapter(sql_string, con);
            d_s = new System.Data.DataSet();
        }
    
        public System.Data.DataSet MyDataSet()
        {
            con.Open();
            d_a.Fill(d_s);
            con.Close();
            return d_s;
        }
    }
