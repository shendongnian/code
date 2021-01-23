    var serving = db.Serves
                     .Include(x => x.Orders)
                     .Include(x => x.Orders.Select(x => x.Item)) //here you'll get your items
                     .Where(m => m.Table.Id == ta && m.IsFinished == false)
                     .OrderByDescending(m => m.Id)
                     .FirstOfDefault();
    //and after that your code should work correctly
    if(serving != null) //don't forget check it, if you use FirstOfDefault()
    {
       var groupedOrder = serving.Orders
                .OrderByDescending(m => m.Id)
                .GroupBy(m => m.Item) 
                .Select(g => new
                {
                    Item = g.Key,
                    Numbers = g.Sum(ri => ri.Numbers)
                }).ToList();
    }
