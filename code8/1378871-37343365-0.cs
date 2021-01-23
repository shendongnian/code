    protected void DocNameClick(object sender, EventArgs e)
    {
        LinkButton btn = sender as LinkButton;
        string name = btn.Text;
        if(!String.IsNullOrEmpty(name))
            int index = e.CommandArgument;
    }
