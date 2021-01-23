    protected void ddlstore_SelectedIndexChanged(object sender, EventArgs e)
    {
        int storeId = int.Parse(ddlstore.SelectedValue);
    
        using (StuffContainer context = new StuffContainer())
        {
            var employees = context.Employees
               .Where(x => x.StoreId == storeId)
               .Select(x => x.Id).ToList();
            var customers = context.Customers
               .Where(x => x.StoreId == storeId)
               .Select(x => x.Id).ToList();
    
            foreach(ListItem item in chkemp.Items)
                item.Selected = employees.Contains(int.Parse(item.Value));
            foreach(ListItem item in chkcust.Items)
                item.Selected = customers.Contains(int.Parse(item.Value));
        }
    }
