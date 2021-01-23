    var rows = tbl.Where(x =>
        new[]
        {
            x.obj1,
            x.obj2,
            x.obj3,
            x.obj4,
            x.obj5,
            x.obj6
        }
            .GroupBy(y => y.color)
            .All(g => g.Count() < 4));
         
