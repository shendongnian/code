    protected void Page_Load(object sender, EventArgs e)
    {
        mainMenu.DataSource = new[] { "M1", "M2" };
        mainMenu.DataBind();
    }
    protected void mainMenu_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        var childMenu = e.Item.FindControl("childMenu") as ListView;
        // will always be null, because ID scope is not correct
        ListView recommendedProducts1 = e.Item.FindControl("recommendedProducts") as ListView;
        // query the correct ID scope, but Items will be empty
        foreach (var item in childMenu.Items)
        {
            var recommendedProducts2 = item.FindControl("recommendedProducts") as ListView;
        }
        // initialize sub-items
        childMenu.DataSource = new object[] { "C1", "C2" };
        childMenu.DataBind();
        // query the correct ID scope, with items
        foreach (var item in childMenu.Items)
        {
            // finally, recommendedProducts for each childmenu-item within the currently processed childmenu is accessible
            var recommendedProducts3 = item.FindControl("recommendedProducts") as ListView;
            recommendedProducts3.DataSource = new[] { "Best" };
            recommendedProducts3.DataBind();
        }
    }
