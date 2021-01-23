    string items = string.Empty;
    foreach (ListItem item in program.Items)
    {
        if(item.Selected)
        {
            items &= item.Text;
        }
    }
    SqlDataSource1.InsertParameters["FirstName"].DefaultValue = FirstName.Text;
    SqlDataSource1.InsertParameters["LastName"].DefaultValue = LastName.Text;
    SqlDataSource1.InsertParameters["address"].DefaultValue = address.Text;
    SqlDataSource1.InsertParameters["program"].DefaultValue = items;
    SqlDataSource1.Insert();
