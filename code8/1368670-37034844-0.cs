    int userid;
    SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
    SqlCommand cmd = new SqlCommand();
    
    cmd.CommandText = "SELECT [ID] FROM [users] WHERE ([email] = @myuser)";
    cmd.CommandType = CommandType.Text;
    cmd.Connection = sqlConnection1;
    
    sqlConnection1.Open();
    
    using (SqlDataReader reader = cmd.ExecuteReader())
    {
    	while (reader.Read())
    	{
    		userid =  Convert.ToInt16(reader.GetValue(reader.GetOrdinal("ID")));
    	}
    }
    
    sqlConnection1.Close();
