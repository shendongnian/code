     public void delete()
        { 
    foreach (GridViewRow g in GridView1.Rows)
    {
	  if(g.RowType == DataControlRowType.DataRow)
    { 
	 Label lblname = (Label)g.FindControl("lblname");
	 SqlCommand cmd = new SqlCommand("delete from clientrequest where client_name='" + lblname.Text + "'", con);
        con.Open();
        cmd.ExecuteNonQuery();
        Response.Redirect("welcome.aspx");
        con.Close();
	}             
    }
    }
