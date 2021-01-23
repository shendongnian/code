    var maxAges = ctx.User.GroupBy(x => x.FirstName)
                          .Select(g => new {
                             firstName = g.Key,
                             maxAge = g.Min(x => x.BirthDate)
                          });
    var result = from u in ctx.User
                 join a in maxAges on new{u.FirstName, u.BirthDate} equals new{a.firstName, a.maxAge}
                 select u;
                                   
