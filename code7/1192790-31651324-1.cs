         var exp = from log in db.Places
                          where log.IsActive==true
                          select new
                              {
                                  logId= log.Id,,
                                  experiences = from exp in log.Experiences 
                                             where(log1.LanguageId==1)
                                             select new
                                                 {
                                                     id=log1.Id,
                                                     title=log1.Title
                                                 }
                              };
