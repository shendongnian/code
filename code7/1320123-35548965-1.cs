    productList.GroupBy(p => new { p.Id, p.Name })
               .Select(x =>new {
                          Id =x.Key.Id, 
                          Name = x.Key.Name
                          Color = String.Join(",", x.Select(c=> c.Color)) 
                   }); 
