    var queryable = db.Users.Where(x => x.Enabled && !x.Deleted);
    // Filter
    var userId = User.Identity.GetUserId();
    queryable = queryable.Where(x => x.AspNetUser.Id == userId);
    queryable = queryable.Where(x => x.Status >= 2); 
    // ...etc
