            using (var connection = new SqlConnection("connectionstringHere"))
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText =  "uspGetAddress"
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@sdate" , SqlDbType = SqlDbType.DateTime , Value = DateTime.Now /* bind your value*/});
                cmd.Parameters.Add(new SqlParameter() { ParameterName = "@edate" , SqlDbType = SqlDbType.DateTime , Value = DateTime.Now /* bind your value*/});
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read()){
                 //do your work, 
                }
                cmd.Connection.Close();
                cmd.Dispose();
                connection.Close();
                connection.Dispose();
            }
