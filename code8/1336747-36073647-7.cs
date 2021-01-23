	protected void Button2_Click(object sender, EventArgs e)
	{
        int transactionID = hfID.Value;
	    try
	    {
	        using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
	            SqlCommand cmd = new SqlCommand("TransactionSave", conn);
                cmd.Parameters.AddWithValue("@ID", transactionID);
                cmd.Parameters.AddWithValue("@Passengers", DropDownList1.SelectedValue);
	            transactionID = cmd.ExecuteScalar();
                hfID.Value = transactionID;
            }
	    }
	    catch(Exception ex)
	    {
	        Response.Write("Error: " + ex.ToString());
	    }
	}
