    IQueryable<Item> data = Enumerable.Range(1, 10000).Select(i => new Item()
    {
            SomeProperty = i
    }).AsQueryable();
    
    Expression<Func<Item, bool>> expression = x => x.SomeProperty > 50;
    
    var obj = data.Provider.Execute(expression);
