    protected void grd1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
            Label lbl=e.Row.FindControl("your cotrol Id")as Label;
           if(lbl!=null && lbl.Text.Trim()=="some string")
           {
               e.Row.FindControl("deactivate btn Id").Visible = false;
               e.Row.FindControl("delete btn Id").Visible = false;
               e.Row.FindControl("edit btn Id").Visible = false;
           }
       }
     }
