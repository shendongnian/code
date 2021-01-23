        IEnumerable<Opinion> opinions = (from o in db.Opinion
                                         select new OpinionDTO
                                         {
                                             Content = o.Content
                                         }).ToList();
        //var randomOpinions = db.Opinion.Where(a => a.Date >= DateTime.Parse("2015-01-01")).OrderBy(g => Guid.NewGuid()).Take(6).ToList();
        IEnumerable<Person> authors = (from p in db.Person
                                       join o in db.Opinion
                                       on p.PersonId equals o.PersonId
                                       select new PersonDTO
                                       {
                                           FullName = p.FirstName + p.LastName,
                                       }).ToList();
