    private string GetSqlScalar(string strSqlCommand, params SqlParameter[] parameters)
    {
        string result = "";
        using (SqlConnection connection = new SqlConnection(strConnectionString))
        using (SqlCommand command = new SqlCommand(strSqlCommand, connection))
        {
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            connection.Open();
            result = (string)command.ExecuteScalar();
        }
    
        return result;
    }
