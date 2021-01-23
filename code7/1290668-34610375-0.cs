    group q.UserId by new
                         {
                             q.UserId
                                               
                         } into qq
                         select new
                         {
                             UID = qq.Key,
                             TimeStamp = qq.Max(x=>x.TimeStamp)
                         })
