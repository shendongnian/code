    DateTime dt = DateTime.Today.AddDays(-14);
    var query = db.YourTable
                   .Where(r=> r.SearchTags != null && 
                          r.SearchTags.Trim() != "" &&
                          r.MediaDate >= dt)
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
