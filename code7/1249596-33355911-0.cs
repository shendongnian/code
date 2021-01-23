        public void InsertDataToDb()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].
                ConnectionString;
            var records = GetRecords();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd =
                    new SqlCommand(
                        "INSERT INTO TableName (param1, param2, param3) " +
                        " VALUES (@param1, @param2, @param3)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@param1", DbType.String);
                cmd.Parameters.Add("@param2", DbType.String);
                cmd.Parameters.Add("@param3", DbType.String);
                foreach (var item in records)
                {
                    cmd.Parameters[0].Value = item.param1;
                    cmd.Parameters[1].Value = item.param2;
                    cmd.Parameters[2].Value = item.param3;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
