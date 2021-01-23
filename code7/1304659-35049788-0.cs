    // GET all products
    var list = ctx.Products.ToList();
    
    // GROUP by category, ORDER by date descending, SKIP 10 rows by category
    var groupByListToRemove = list.GroupBy(x => x.Category)
                                  .Select(x => x.OrderByDescending(y => y.CreatedDate)
                                                .Skip(10).ToList());
    
    // SELECT all data to remove
    var listToRemove = groupByListToRemove.SelectMany(x => x);
    
    // Have fun!
    ctx.Products.RemoveRange(listToRemove);
