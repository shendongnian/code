      var oldestUsers = (from u in users
                           group u by u.FirstName into grp 
                           select new {
                               grp.Key,
                               oldestUser = (from u in grp
                                             orderby u.BirthDate descending
                                             select u).First()
                           }).ToList();
    
        foreach (var u in oldestUsers)
        {
            Console.WriteLine("{0} {1:D}", u.oldestUser.FirstName, u.oldestUser.BirthDate);
        }
