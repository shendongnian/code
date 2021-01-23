    var people = File.ReadLines(fileName)
        .Select((l,i) => new { Line = l.Split('|'), LineNo = i })
        .GroupBy(x => x.LineNo/2)
        .Select(grp => new Person
             {
                 city = grp.First().Line[0].Trim(),
                 country = grp.First().Line[1].Trim(),
                 phone = grp.First().Line[2].Trim(),
                 name = grp.Last().Line[0].Trim()
             })
        .ToList();
