    string[] joinColumnNames = { "Country", "Company", "DateId" };
    var Join = 
        from PX in pullX.AsEnumerable()
        join PY in pullY.AsEnumerable()
        on     string.Join("\0", joinColumnNames.Select(c => PX[c] + "").ToArray())
        equals string.Join("\0", joinColumnNames.Select(c => PY[c] + "").ToArray())
        into Outer
        from PY in Outer.DefaultIfEmpty<DataRow>(pullY.NewRow())
        select new { PX, PY };
