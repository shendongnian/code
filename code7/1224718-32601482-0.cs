    var result = db.Item.GroupBy(x => new { x.Type, x.ExpiryDate })
                        .Select(x => new 
                                     {
                                         Type = x.Key.Type,
                                         Days = (DateTime.Now.Date - x.Key.ExpiryDate).Days
                                     };
