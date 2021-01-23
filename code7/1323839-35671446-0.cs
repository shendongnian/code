    public void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        ListViewItem item = (ListViewItem)(ddl.NamingContainer);
        Label lbl = item.FindControl("lblEachPrice") as Label;
        lbl.Text = ddl.SelectedValue.ToString();
    }
