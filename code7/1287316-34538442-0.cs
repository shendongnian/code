    using (ClientContext context = new ClientContext(projURL))
    {
        CamlQuery query = new CamlQuery();
        query.ViewXml = "";
        ListItemCollection items = context.Web.SiteUserInfoList.GetItems(query);
        context.Load(items);
        context.ExecuteQuery();
        foreach (ListItem item in items)
        {
            DateTime hireDate = (DateTime)item["Created"];
            if(hireDate > DateTime.Today.AddDays(-30))
            {
                Console.WriteLine(item["Name"]);
            }
        }
        Console.ReadLine();
    }
