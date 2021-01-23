    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "GetIndex")
      {
        GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
        gvr.RowState = DataControlRowState.Selected;
       }
    }
