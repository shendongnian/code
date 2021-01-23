    var source = (from item in baseSource
                              
                              where item.Version > 0 
                              where item.Published                           
                              where db.abcTest.Where(it => it.Published && it.Name == item.Name).Max(it => it.Version) == item.Version
                              
                              orderby item.Name, item.Version descending
                              group item by new { item.Name, item.Version} into groupx
                              select new
                              {          
                                    PK = groupx.FirstOrDefault().PK,
                                    groupx.Key.Name,
                                    groupx.Key.Version,
                                    abc= groupx.Select(it => it.abc.Count()).FirstOrDefault()
                              }
                              ).ToList();
                return source;
