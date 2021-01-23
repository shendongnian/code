    var query= Context.Tours
                .Join(Context.TourCategories, t => t.TourId, tc => tc.TourId,
                    (t, tc) => new { t.TourId, t.Name, tc.CategoryId})
                .Join(Context.Categories, x => x.CategoryId, c => c.CategoryId,
                    (x, c) => new { x.TourId, TourName = x.Name, CategoryName = c.Name})
                .GroupBy(x => new { x.TourId, x.TourName }).ToList()
    var result=query.Select( g=> new VwTourWithCategories
                    {
                        TourId = g.Key.TourId,
                        Name = g.Key.TourName,
                        Categories = string.Join(",", g.Select(i => i.CategoryName))
                    });
