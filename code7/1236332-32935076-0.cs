    using (SqlConnection sqlConnection = new SqlConnection())
    using (SqlCommand sqlCommand = new SqlCommand())
    {
        sqlConnection.ConnectionString = "....."";
        sqlCommand.Connection = sqlConnection;
        sqlCommand.CommandText = @"SELECT COUNT(*) FROM dbo.Users 
                            WHERE Name = @name";
        sqlConnection.Open();
        sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = textBox2.Text;
        int result = Convert.ToInt32(sqlCommand.ExecuteNonQuery());
        if(result > 0) 
            MessageBox.Show("Founded " + result + " user/s");
        else
            MessageBox.Show("No user found with that name");
    }
