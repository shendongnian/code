new ChartModel
    {
        Date = g.Select(v=>v.MonthYear).FirstOrDefault(),
        GreatDay = g.Select(e=>e.Great).Sum(),
        LateEntry = g.Select(e => e.LateEntry).Sum(),
        LeftEarly = g.Select(e => e.LeftEarly).Sum(),
        TotalAttendance = g.Select(e => e.TotalAttendance).Sum(),
    });
</pre>
