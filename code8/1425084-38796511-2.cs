    var Join = 
        from PX in pullX.AsEnumerable()
        join PY in pullY.AsEnumerable() 
        on     string.Join("\0", new string[]{ PX[joinColumnNames[0]] + "", PX[joinColumnNames[1]] + "" }) 
        equals string.Join("\0", new string[]{ PY[joinColumnNames[0]] + "", PY[joinColumnNames[1]] + "" })
        into Outer
        from PY in Outer.DefaultIfEmpty<DataRow>(pullY.NewRow())
        select new { PX, PY };
