    protected void btndelete_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        string name = ((Label)gvr.FindControl("lblname")).Text;
        delete(name);
        GridView1.Visible = false;
    
    }
