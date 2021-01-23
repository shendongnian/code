        private const string SQL_CONNECTION = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        private DataTable GetTable()
        {
            var table = new DataTable();
            using (var con = new System.Data.SqlClient.SqlConnection(SQL_CONNECTION))
            {
                con.Open();
                using (var cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM MyTable;", con))
                {
                    table.Load(cmd.ExecuteReader());
                }
            }
            return table;
        }
        private int SaveApproved(int rowID, bool approved)
        {
            using (var con = new System.Data.SqlClient.SqlConnection(SQL_CONNECTION))
            {
                con.Open();
                using (var cmd = new System.Data.SqlClient.SqlCommand("UPDATE MyTable SET IsApproved=@IsApproved WHERE ID=@ID;", con))
                {
                    cmd.Parameters.Add("@IsApproved", SqlDbType.Bit).Value = approved;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = rowID;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
