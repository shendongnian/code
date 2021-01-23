    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
     {
     
     if (e.Row.RowType == DataControlRowType.DataRow)
      {
              
        Label lbl_ID = (Label)e.Row.FindControl("lbl_ID");
        string Id = lbl_ID.Text.Trim();
      }
    }
