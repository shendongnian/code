    using( var dbContext=...)
    {
       var results = from s in dbContext.conflocations
                     group s by s.StateId into grp
                     select new { 
                                  StateId = key,
                                  StateName= grp.Max(x=>x.Name),
                                  Count = grp.Count()
                                };
       ...
    }
