    var res = 
    (
        from a in AList
        group a by a.Date into g
        select new B
        {
            Date = g.Key,
            C = 
            (
                from c in g
                select new C
                { 
                    Hour = c.Hour, 
                    Value = c.Value 
                }
            ).ToList()
        }
    ).ToList();
