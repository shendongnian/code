	protected void Button2_Click(object sender, EventArgs e)
	{
        int rowsAffected = 0;
	    try
	    {
	        using(SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString))
            {
	            SqlCommand cmd = new SqlCommand("TransactionSave", conn);
                cmd.Parameters.AddWithValue("@ID", HiddenFieldID.Value);
                cmd.Parameters.AddWithValue("@Passengers", DropDownList1.SelectedValue);
	            rowsAffected = cmd.ExecuteNonQuery();
            }
	    }
	    catch(Exception ex)
	    {
	        Response.Write("Error: " + ex.ToString());
	    }
	    Response.Redirect("Payment.aspx");
	}
