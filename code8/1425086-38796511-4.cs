    var Join = 
        from PX in pullX.AsEnumerable()
        join PY in pullY.AsEnumerable()
        on     string.Join("\0", joinColumnNames.Select(c => PX[c]))
        equals string.Join("\0", joinColumnNames.Select(c => PY[c]))
        into Outer
        from PY in Outer.DefaultIfEmpty<DataRow>(pullY.NewRow())
        select new { PX, PY };
