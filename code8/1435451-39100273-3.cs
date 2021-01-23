    group new { p, s } by p.ProjectId into g
    let p = g.FirstOrDefault().p
    select new
    {
        ProjectId = g.Key,
        ProjectName = p.Name,
        Sequences =
            (from e in g
             group e.s by e.s.SequenceId into g2
             let s = g2.FirstOrDefault()
             select new
             {
                 SequenceId = g2.Key,
                 SequenceName = s.Name
             }).ToList()
    };
