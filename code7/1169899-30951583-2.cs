    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        Session["Selected"] = e.Item.Text;
        if (e.Item.Text == "Page1")
        {
            Response.Redirect("~/menu/default.aspx");
        }
        else if(e.Item.Text == "Page2")
        {
            Response.Redirect("~/menu/default2.aspx");
        }
        else if (e.Item.Text == "Page3")
        {
            Response.Redirect("~/menu/default3.aspx");
        }
    }
