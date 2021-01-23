        /// <summary>
        /// Returns a DataSet given an Sql Command
        /// </summary>
        /// <param name="cmd">The SqlCommand object</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDataSet(SqlCommand cmd)
        {
            using (SqlConnection con = DbConnect()) // DbConnect() returns SqlConnection instance
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection = con;
                da.Fill(ds, "my_dataset");
                return ds;
            }
        }
