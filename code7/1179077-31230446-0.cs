    public void AddDDL()
    {
        var tmp = new DropDownList();
        tmp.SelectedIndexChanged += ddl_SelectedIndexChanged;
        Page.Controls.Add(tmp);
    }
    
    protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ddl = sender as DropDownList;
        var lists = Session["dropdownlists"] as Dictionary<DropDownList, int>;
        lists[ddl] = ddl.SelectedIndex;
    }
