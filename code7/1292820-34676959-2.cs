    var result = (from s in ServiceRequests // define the data source
                 group s by s.SR_Status into g  // group all items by status
                 orderby g.Count() descending // order by count descending
                 select new { g.Key, Total = g.Count() }) // cast the output
                 .Take(5) // take just 5 items
                 .ToDictionary(x => x.Key, x => x.Total); // cast to dictionary
