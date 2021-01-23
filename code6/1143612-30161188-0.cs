    foreach (GridViewRow row in GridView1.Rows) {
    		
    	Label lblFname = (Label)row.FindControl("lblFname");
    	Label lblFaName = (Label)row.FindControl("lblFaName");
    	Label lblLName = (Label)row.FindControl("lblLName");
    	DropDownList ddl_att = (DropDownList)row.FindControl("ddlDesignation");
    	DropDownList ddl_rmk = (DropDownList)row.FindControl("ddlRemark");
    
    	dataInsert(lblFname.Text,lblFaName.Text,ddl_att.SelectedValue);
    
    }
    
     
    public void dataInsert(string First_name,string Father_name,string Attendance)
    {
     using (SqlConnection con = new SqlConnection(conn.ConnectionString))
    	{
    		using (SqlCommand cmd = new SqlCommand())
    		{
    			cmd.CommandText = "yourInsertQuery";
    			cmd.Connection = con;
    			cmd.CommandType = CommandType.Text;
    			cmd.Parameters.AddWithValue("@First_name", First_name);
    			cmd.Parameters.AddWithValue("@Father_name", Father_name);
    			cmd.Parameters.AddWithValue("@Attendance", Attendance);
    				...
    				... 	
    			con.Open();
    			cmd.ExecuteNonQuery();
    		}
    		con.Close();
    	}
    }
