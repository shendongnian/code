    protected void GridView1__RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                 TextBox txtControl = (TextBox)e.Row.FindControl("TextBox31");
            }
         }
