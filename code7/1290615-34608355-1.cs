    var query = (
        from user in db.Users // note: removed ToList() here 
                              // to avoid premature query materialization
        where //TODO ADD WHERE CLAUSE HERE ?
        let followIds = user.FollowTables.Select(f => f.FollowId)
        let notFollowIds = (from user2 in db.Users
                            where !followIds.Contains(user2.Id)
                            select user2.Id)
        select new 
        {
            UserName = user.UserName,
            Idfollowing = followIds.ToArray(),
            Idnotfollowing = notFollowIds.ToArray()
        })
         // TODO add paging? .Skip(offset).Take(pageSize)
         .ToList();
