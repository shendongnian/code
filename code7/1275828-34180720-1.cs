    var query = from a in ...
    select new
    {
        C = a.Amount1
    };
    
    var query2 = from b in ...
    select new
    {
        A = b.Amount2,
        B = b.Amount3,
    };
    
    var query3 = query.Cast<object>().Concat(query2.Cast<object>());
