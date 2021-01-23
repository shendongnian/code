    using( var dbContext=...)
    {
       var results = from c in dbContext.conflocations
                     from s in dbContext.States.Where(x=>x.Id = c.StateId).DefaultIfEmpty()
                     group new {c, s} by s.StateId into grp
                     select new { 
                                  StateId = grp.Key,
                                  StateName= grp.Max(x=>x.s.Name),
                                  Count = grp.Count()
                                };
       ...
    }
