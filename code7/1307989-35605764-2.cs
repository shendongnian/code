    public static DataTable GetAllCargos()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT * FROM CARGO";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BRconn"].ToString()))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
