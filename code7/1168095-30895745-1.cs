    var result = (from con in Table2
    join name1 in Table1 on con.Id1 equals name1.Id
    join name2 in Table1 on con.Id2 equals name2.Id
    where !string.IsNullOrEmpty(name1.Name) && !string.IsNullOrEmpty(name2.Name)
    group new {con.Id1, con.Id2, con.MatchLevel, name1.Name, name2.Name} by name2 into grp
    select new {res = grp.OrderbyDescending(x=>x.MatchLevel).FirstOrDefault()})
