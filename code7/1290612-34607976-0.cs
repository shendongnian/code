    var ret = (from user in db.Users.ToList()
                  select new 
                   {
                    UserName = user.UserName,
                    Idfollowing = user.FollowTables.Select(x=> x.Id)
                    Idnotfollowing = db.FollowTables.Where(x=> !user.FollowTables.Select(x=> x.Id).Contains(x.Id)).Select(x=> x.Id)
                 });
