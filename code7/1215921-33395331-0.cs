    var result = (from m in db.Messages
                  orderby m.Subject
                  select new MetaMsg
                  {
                      Subject = m.Subject, 
                      SentDate = m.SentDate,
                      FromName = (from f in db.From
                                  where m.FromId == f.ID                                  
                                  select f.Name).FirstOrDefault(),
                      /* If you have navigation properties setup, you may be able to do this */
                      FromName = m.From.Name,
                  }).Take(10).ToList();
