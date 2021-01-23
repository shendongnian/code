    protected void comnt_Gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text=="R")
            {
                 LinkButton myLinkButton = (LinkButton)e.Row.FindControl("myLinkButton");
                 myLinkButton.Text = "Rejected";
                 myLinkButton.ForeColor = System.Drawing.Red;
             }
         }
    }
