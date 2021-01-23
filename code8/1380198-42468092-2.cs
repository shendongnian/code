    protected void EntityDataSource1_QueryCreated(object sender, QueryCreatedEventArgs e)
    {
       var ordersQuery = e.Query.OfType<Orders>();
       e.Query = ordersQuery.Include("Clients")
       .GroupBy(i => i.Clients.ClientName)
       .Select(i => i.OrderByDescending(it => it.OrderDate).FirstOrDefault());
    }
