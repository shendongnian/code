        public static void Main()
        {
            string connectionString = "SERVER=MyServer;DATABASE=MyDatabase";
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE username = @username");
            cmd.Parameters.Add(new SqlParameter("username", "Someuser"));
            DataSet dataSet = ExecuteDataset(cmd, connectionString);
            DataTable table = dataSet.Tables[0];
            string someValue = table.Rows[0]["MyField"].ToString();
        }
        public static DataSet ExecuteDataset(SqlCommand cmd, String connectionString)
        {
            // Create the SqlConnection, DataAdapter & DataSet
            using (SqlConnection sqlConn = new SqlConnection(connectionString))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataSet dataSet = new DataSet();
                // Fill the DataSet
                cmd.Connection = sqlConn;
                da.Fill(dataSet);
                // Return the dataset
                return dataSet;
            }
        }
