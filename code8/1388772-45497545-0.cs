            DataTable dt = new DataTable();
            using (var con = new SqlConnection { ConnectionString = "ConnectionString" })
            {
                using (var command = new SqlCommand { Connection = con })
                {
                    con.Open();
                    command.CommandText = @"SELECT statement.....";
                    command.Parameters.AddWithValue("@param", "Param");
                    //load the into DataTable
                    dt.Load(command.ExecuteReader(), LoadOption.Upsert);
                }// this will dispose command
            }// this will dispose and close connection
