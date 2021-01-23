    var results= collection.GroupBy(g=> new {g.PS_DID,  g.ID , g.TITLE,  g.ACTIVE})
              .OrderBy(x=>x.Key.PS_DID)
              .Select(x=> new 
               {
                    PS_DID = g.Key.PS_DID,
                    ID = g.Key.ID,
                    TITLE = g.Key.TITLE,
                    ACTIVE = g.Key.ACTIVE,
                    STATUS_VALID_DATE = x.GroupBy(g=> g.status)
                                         .Select(s=> new {
                                              status = s.Key, 
                                              validFrom = s.Select(v=>v.validrom).ToList() 
                                         }).ToList()
               });
  
