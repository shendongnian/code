    protected void gvData_RowCreated(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string itemNbr = e.Row.Cells[1].Text;
            LinkButton lb = new LinkButton();
            lb.Text = itemNbr;
            lb.Click += genericLinkButton_Click;
            foreach (Control ctrl in e.Row.Cells[1].Controls)
            {
                e.Row.Cells[1].Controls.Remove(ctrl);
            }
            e.Row.Cells[1].Controls.Add(lb);
        }
    }
