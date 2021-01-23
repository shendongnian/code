        try
    {
	
	//get values from text boxes for values you want to update in a string array queryarr
	//here it has 3 fields id, name, address.
	
	for(int i=0; i<5; i++)
	{
	  try
	  {
        string connectionString =
            "server=myown;" +
            "initial catalog=something;" +
            "user id=somebody;" +
            "password=secret";
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd =
                new SqlCommand("UPDATE EmployeeDetails SET Name=@NewName, Address=@NewAddress" +
                    " WHERE Id=@Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", queryarr[i,0]);
                cmd.Parameters.AddWithValue("@Name", queryarr[i,1]);
                cmd.Parameters.AddWithValue("@Address", queryarr[i,2]);
                cmd.ExecuteNonQuery();
               
            }
        }
	  }
	   catch (SqlException ex)
      {
        //Log the exception but do not display any message.        
      }	
    
	}
	}
    catch (Exception ex)
    {
        //display error message
        
    }
