    var query = from item in context.Table1s
        group item by new
        {
           item.User, 
           Year = SqlFunctions.DatePart("yyyy", item.Date), 
           Month = SqlFunctions.DatePart("mm", item.Date), 
           Day = SqlFunctions.DatePart("dd", item.Date)
        } into g
        select new { g.Key.User, g.Key.Year, g.Key.Month, g.Key.Day, Count = g.Count() };
