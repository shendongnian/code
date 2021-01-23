    int index;
    public void Gridcommandevent(object sender, GridViewCommandEventArgs ev)
    {
        if (ev.CommandName == "Update")
        {
           index = Convert.ToInt32(ev.CommandArgument);
        }
    }
    
    protected void GridView3_RowCommand(object sender, GridViewUpdateEventArgs e)
    {   
        String strConnString = ConfigurationManager.ConnectionStrings["DGCodLocConnection"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
    
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Parts SET [LastModified] = '" + Permit + "' WHERE PartsID = '" + index + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
    }
