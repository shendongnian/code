    protected void btnOpen_Click(object sender, EventArgs e)
    {
        // Find the index to select
        Button btnOpen = (Button)sender;
        GridViewRow row = (GridViewRow)btnOpen.NamingContainer;
        int selectedIndex = row.DataItemIndex;
        // Set the selected index of the GridView
        GridView1.SelectedIndex = selectedIndex;
        // Bind the detail GridView now that the row is selected so 
        // that its SqlDataSource can get a SelectedValue for the
        // parent GridView
        gvDetail.DataBind();
    }
                
