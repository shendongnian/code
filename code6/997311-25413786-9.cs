    var query = db.YourTable
                   .Where(r=> r.SearchTags != null && r.SearchTags.Trim() != "")
                   .Select(r=> r.SearchTags)
                   .AsEnumerable()
                   .Select(r => r.Split(','))
                   .SelectMany(r => r)
                   .GroupBy(r => r)
                   .Select(grp => new
                       {
                           Key = grp.Key,
                           Count = grp.Count()
                       });
               });
