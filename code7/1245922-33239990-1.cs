    var list = (from u in ManageEntity.AspNetUsers
               select new UserDetail
                  {
                     UserName = u.UserName,
                     LockoutEnabled = u.LockoutEnabled,
                     AccessFailedCounts = u.AccessFailedCount
                  }).ToList();
