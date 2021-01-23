    private void btnupdate_Click(object sender, EventArgs e) 
    {
    	try 
    	{
    		string c = ConfigurationManager.ConnectionStrings["LMS"].ConnectionString;
    		SqlConnection con = new SqlConnection(c);
    		con.Open();
    		SqlCommand cmd = new SqlCommand("IssueUpdate", con);
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = "Enter Value here";
    		cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 50).Value = "Enter Value here";
    		cmd.Parameters.Add("@DateIssue", SqlDbType.DateTime).Value = "Enter Value here";
    		cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = "Enter Value here";
    		cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = "Enter Value here";
    		cmd.ExecuteNonQuery();
    		con.Close();
    		storedproc();
    	}
    	catch (Exception ex) 
    	{
    		Console.WriteLine("SqlError" + ex);
    	}
    }
