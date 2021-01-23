    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow gr = ((sender as HyperLink).NamingContainer as GridViewRow);
        Session["destype"] = gr.Cells[0].Text.Trim(); /*For first cell value of Row */
        //Session["abc"] = gr.Cells[2].Text.Trim(); /*Repeat for other cell values of Row by increasing cell index */
        Response.Redirect("~/home.aspx");        
    }
