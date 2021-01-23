    // To make it easier to create sql query put all search string in array
    string[] search = ListB.Select(b => b.Search).ToArray();
    List<XLS2015> ListA = db.XLS2015
        .Where(a => search.Contains(a.F20))
        .AsEnumerable() // execute on server at this point, and do rest in C#
        .Join(ListB, a => a.F20, b => b.Search, (a, b) => new { A = a, B = b })
        .Select(x => {
            // do replacement
            x.A.F20 = x.A.F20.Replace(x.B.Search, x.B.Replacement);
            return x.A;
        })
        .ToList();
