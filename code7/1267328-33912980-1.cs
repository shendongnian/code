    string sqlQuery = "INSERT INTO ItemDetails.item(description,category_id) VALUES (@item_desc,@cat_id)";
    
    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
    {
    	cmd.CommandType = CommandType.Text;
    
    	cmd.Parameters.Add("@item_desc", SqlDbType.VarChar, 1000).Value = txtitemdesc.Text;
    	cmd.Parameters.Add("@cat_id", SqlDbType.Int).Value = GetCategoryID();
    
    	try
    	{
    		con.Open();
    		int result = cmd.ExecuteNonQuery();
    		if (result > 0)
    		{
    			MessageBox.Show("Record Inserted Successfully!");
    		}
    		else
    		{
    			MessageBox.Show("Failed to add record");
    		}
    	}
    	catch (SqlException ex)
    	{
    		MessageBox.Show("An error has occured! " + ex);
    	}
    	finally
    	{
    		con.Close();
    	}
    }
