    var minMaxInfo = minMaxList
        .Skip(1)
        .Aggregate(
            new
            { 
                Max = minMaxList[0].Max,
                MaxIndex = 0,
                Min = minMaxList[0].Min,
                MinIndex = 0,
                Index = 0
            },
            (pre, t) =>
            {
                pre.Index++;
                if (t.Min < pre.Min)
                {
                   pre.Min = t.Min;
                   pre.MinIndex = t.Index;
                }
                if (t.Max > pre.Max)
                {
                   pre.Max = t.Max;
                   pre.MaxIndex = t.Index;
                }
                return pre;
            })
