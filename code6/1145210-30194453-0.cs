    var items = users.Select(u => new
    {
        User = u,
        ProductsTask = this.repository.GetProducts(u.UserName)
    }).ToList();
    await Task.WhenAll(items.Select(x => x.ProductsTask));
    //Ignore the return value of `WhenAll` and just use the `items` collection
    foreach (var item in items)
    {
        var user = item.User;
        List<Product> products = item.ProductsTask.Result;
        //Accessing Task.Result is fine here, we know task already completed.
    }
