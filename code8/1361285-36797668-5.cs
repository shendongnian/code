    var query= Context.Tours.Select(t=> new 
                                        {
                                         t.TourId, 
                                         t.Name,
                                         CategoryNames = t.TourCategories.Select(tc=>tc.Category.Name)
                                         } 
                                    ).ToList();
    var result=query.Select( g=> new VwTourWithCategories
                    {
                        TourId = g.Key.TourId,
                        Name = g.Key.TourName,
                        Categories = string.Join(",", g.Select(i => i.CategoryName))                 
                    });
 
