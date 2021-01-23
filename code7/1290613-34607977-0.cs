    var ret = (from user in db.Users.ToList()
               select new 
                 {
                    UserName = user.UserName,
                    Idfollowing = user.FollowTables.Where(x => x.UserId == user.Id)
                                      .Select(x => x.FollowId).ToArray(),
                    Idnotfollowing = user.FollowTables.Where(x => x.UserId != user.Id)
                                      .Select(x => x.FollowId).ToArray()
                });
