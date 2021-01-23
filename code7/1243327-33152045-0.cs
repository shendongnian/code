    SqlCommand sqlCommand = new SqlCommand();
    sqlCommand.Connection = sqlConnection;
    sqlCommand.CommandType = CommandType.Text;
    sqlCommand.CommandText = sqlString;
    sqlConnection.OpenAsync();
    mytextArea.Append(sqlConnection.ConnectionTimeout.ToString());
    
    sqlCommand.Parameters.Add("@appuserType");
    sqlCommand.Parameters.Add("@appCode");
    
    foreach (var user in mylist)
    {
    
    	sqlCommand.Parameters["@appuserType"].Value = user.UserType;
    	sqlCommand.Parameters["@appCode"].Value = user.AppCode;
    	sqlCommand.ExecuteNonQuery();
    	rowsAffected++;
    
    }
    sqlConnection.Close();
