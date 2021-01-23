    var result = db.list.GroupBy(x => new { x.Number, x.ContactID  })
                        .Where(x => x.Count() > 1)
                        .Select(x => new 
                                     {
                                         Number = x.Key.Number,
                                         ContactID = x.Key.ContactID  
                                     });
