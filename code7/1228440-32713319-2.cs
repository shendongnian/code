    using (var session = store.OpenAsyncSession())
    {
        var queryable = session.Query<Customers_ByName.QueryModel, Customers_ByName>()
            .Customize(c =>
            {
                //just to do some customization to look more like OP's query
                c.RandomOrdering();
            })
            .ProjectFromIndexFieldsInto<CustomerViewModel>();
        var enumerator = await session.Advanced.StreamAsync(queryable);
        var customerViewModels = new List<CustomerViewModel>();
        while (await enumerator.MoveNextAsync())
        {
            customerViewModels.Add(enumerator.Current.Document);
        }
        Console.WriteLine(customerViewModels.Count); //in my case 504
    }
