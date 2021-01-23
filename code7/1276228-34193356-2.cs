    protected void MainGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
           LinkButton myLink = new LinkButton();
           myLink.ID = "LinkButton1";
           myLink.Text = "LinkButton";
           myLink.Click += myLink_Click;
           e.Row.Cells[0].Controls.Add(myLink);
       }
    }
