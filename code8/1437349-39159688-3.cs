    var result = (from item in dt
                  group new { item.ATTRIBUTE_NAME, item.ATTRIBUTE_DESCRIPT }
                  by new { item.PARENT_CODE, item.CHILD_COD } into g
                  select new 
                  {
                      g.Key,
                      Items = g.ToList();
                  });
