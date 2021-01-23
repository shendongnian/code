    string que = "SELECT Name FROM StudentInfo WHERE StudentNo = @StudentNo"
    
    using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["connection"].ConnectionString))
    {
    	using (SqlCommand command = new SqlCommand(sql, connection))
    	{
    		command.Parameters.Add("@StudentNo", SqlDbType.VarChar, 50).Value = textBox1.Text;
    		
    		//If StudentNo is Int
    		//command.Parameters.Add("@StudentNo", SqlDbType.Int).Value = (int) textBox1.Text;
    
    		connection.Open();
    
    		string veri = Convert.ToString(command.ExecuteScalar());
    		return veri;
    	}
    }
