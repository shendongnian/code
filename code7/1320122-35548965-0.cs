    productList.GroupBy(p => new { p.Id, P.Name })
               .Select(x =>new {
                          Id =x.Key.Id, 
                          Name = x.Key.Name
                          Color = String.Join(",", g.Select(x => c.Color)) 
                   }); 
