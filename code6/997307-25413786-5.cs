    var query = db.YourTable
                   .Select(r=> r.SearchTags)
                   .AsEnumerable()
                   .Where(r=> !string.IsNullOrWhiteSpace(r))
                   .Select(r => r.Split(','))
                   .SelectMany(r => r)
                   .GroupBy(r => r)
                   .Select(grp => new
                       {
                           Key = grp.Key,
                           Count = grp.Count()
                       });
               });
