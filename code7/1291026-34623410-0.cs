    string sqlQuery = "Update p SET  p.Date =@dt from Perioada p join Client c on p.ID_Client = c.ID_Client WHERE (c.CNP = @cnp)"
    using (SqlConnection con = new SqlConnection(connectionString))
    {
    	SqlCommand command = new SqlCommand(sqlQuery, con);
	    command.Parameters.AddWithValue("@dt", dateTimePicker1.Value.ToString("MM/dd/yyyy"));
    	command.Parameters.AddWithValue("@cnp", textBox1.Text);
	    try
    	{
	    	con.Open();
		    command.ExecuteNonQuery();
    	}
	    catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
	    }
    }
