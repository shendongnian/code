     var result = (from n in namelist
                  join c in categories 
                  on n.Id equals c.NameId into g
                  select new 
                           {
                              id = n.Id,
                              Name = n.Name,
                              CategorieIds = g.Select(x => x.CategoryId)
                           }).AsEnumerable()
                             .Select(x => new 
                                       { 
                                         Id = x.id, 
                                         Name = x.Name, 
                                         CategoryIds = String.Join(",",x.CategorieIds)) 
                                       });
