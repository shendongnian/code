    int storeId = int.Parse(ddlstore.SelectedValue);
    using (StuffContainer context = new StuffContainer())
    {
    List<Employee> employees = context.Employees.ToList();
    foreach(Employee item in employees)
    {
    if(item.store_id == storeId )
    {
    chkemp.Items.FindByText(item.FName).Selected = true;    
    }
    }
    }
