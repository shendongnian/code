    var query = from item in context.Table1s
        group item by new
        {
            item.User, 
            Date = DbFunctions.TruncateTime(item.Date)
        } into g
        select new { g.Key.User, g.Key.Date, Count = g.Count() };
