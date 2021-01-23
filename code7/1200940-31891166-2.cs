    protected void linkButton_click(object sender, EventArgs e)
    {
        LinkButton btn = (LinkButton)sender;
        GridViewRow row = (GridViewRow)btn.NamingContainer;
    
        string healthCommentStatus = row.Cells[1].Text;
    }
