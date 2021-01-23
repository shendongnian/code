    var dateTree = (from p in persons
                    group p by p.BirthDate into g
                    select new
                    {
                           BirthDate = g.Key,
                           Names = persons.Where(x => x.BirthDate == g.Key).Select(y => y.Name)
                       }).ToList();
