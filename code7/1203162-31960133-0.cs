    var data = (from a in context.TableA
               from b in context.TableB
               where a.ID == b.TableAID
               select new 
               {
                   a.Name,
                   b.Order
               }).Distinct().OrderByDescending(x => x.Order).ToList();
    foreach(var item in data)
    { 
        Console.WriteLine(item.Name);
    }
