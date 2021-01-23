    // First, generate a linq query
    var query = from a in Persons
                join t in Repairs on a.PID equals t.Repairman_PID
                group new { a, t } by new { a.PID, a.Name, a.Surname } into g
                select new
                {
                    PID = g.Key.PID,
                    Name = g.Key.Name,
                    Surname = g.Key.Surname,
                    PhoneCount = g.Count()
                };
    // Then order by PhoneCount descending and take top 3 items
    var list = query.OrderByDescending(t => t.PhoneCount).Take(3).ToList();
