    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       if (e.CommandName == "myLinkButton")
       {
          LinkButton lnk = (e.CommandSource) as LinkButton;
          GridViewRow clickedRow = lnk.NamingContainer as GridViewRow;
       }
    }
   
