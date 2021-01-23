    var qry = _db.ApplicationUsers.OrderByDescending(q => q.DateCreated)
                                  .Select(u => new UserBroadcastDTO {
                                        UserId = u.Id,
                                        DateCreated = u.DateCreated                                   
                                  });
    // do your additional logic then materialize the query   
    var formattedresults = qry.ToList().Select(q => new UserBroadcastDTO {
        UserId = q.Id,
        DateCreated = q.DateCreated.ToString("yyyy-MM-dd hh:mm")
    });
