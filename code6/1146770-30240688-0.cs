    foreach (ListItem item in program.Items)
    {
        if(item.Selected)
        {
        
             SqlDataSource1.InsertParameters["FirstName"].DefaultValue = FirstName.Text;
             SqlDataSource1.InsertParameters["LastName"].DefaultValue = LastName.Text;
             SqlDataSource1.InsertParameters["address"].DefaultValue = address.Text;
             SqlDataSource1.InsertParameters["program"].DefaultValue = item.Text;
    
             SqlDataSource1.Insert();
        }
    }
