            string[] str = new string[] {"sheraz" , "ahmed" , "khan"};
            DataTable tvp = new DataTable();
            tvp.Columns.Add("names");
            foreach (string item in str)
            {
                tvp.Rows.Add(item);
            }
            foreach (DataRow r in tvp.Rows)
            {
                Console.WriteLine(r["names"].ToString());
            }
            SqlConnection conn = new SqlConnection("Data Source=SHZAK;Initial Catalog=synchroniztionTesing;Integrated Security=True");
            conn.Open();
            using (conn)
            {
                SqlCommand cmd = new SqlCommand("strpdPassAnStringArray", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter tvparam = cmd.Parameters.AddWithValue("@List", tvp);
                tvparam.SqlDbType = SqlDbType.Structured;
                cmd.ExecuteScalar();
            }
