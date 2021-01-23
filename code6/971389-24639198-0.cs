    protected void ddPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        // handle event                 
        DropDownList ddpagesize = sender as DropDownList;
        GridView1.PageSize = Convert.ToInt32(ddpagesize.SelectedItem.Text);
        ViewState["PageSize"] = ddpagesize.SelectedItem.Text;    
        SqlDataSource1.SelectCommand = "" + txtSearchValue.Text + "'";          
        GridView1.DataBind();
    }
