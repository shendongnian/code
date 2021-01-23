      string dbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DbName"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
            SqlCommand command = new SqlCommand("Proc Name", sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            
            command.Parameters.Add("@Id", SqlDbType.Int).Value = Id
            command.Parameters.Add("@Name", SqlDbType.VarChar).Value = nameValue;
            sqlConnection.Open();
            command.CommandTimeout = 30;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet result = new DataSet();
            da.Fill(result);
            sqlConnection.Close();
            return result;
