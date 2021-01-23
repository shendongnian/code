            SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            cmd.CommandText = "StoredProcedureName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection1;
            var param1 = cmd.CreateParameter();
            param1.DbType = DbType.String;
            param1.Direction = ParameterDirection.Input;
            param1.ParameterName = "NameOfParameter1";
            param1.Value = "Value";
            cmd.Parameters.Add(param1);
            var param2 = cmd.CreateParameter();
            param2.DbType = DbType.Int32;
            param2.Direction = ParameterDirection.Input;
            param2.ParameterName = "NameOfParameter2";
            param2.Value = 11;
            cmd.Parameters.Add(param2);
            sqlConnection1.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())  // Each row from StoredProcedure
            {
                var returnObject = reader.GetString(0);
            }
            sqlConnection1.Close();
