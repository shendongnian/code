    var query = from proj in context.Project
                join s in context.SubValue.Where(s => s.Created >= startDate && s.Created <= endDate && (s.StatusId == 1 || s.StatusId == 2)) on proj.Id equals s.ProjectId into s2
                from subv in s2.DefaultIfEmpty()
                select new { proj, subv } into x
                group x by new { x.proj.Id, x.proj.Name } into g
                select new {
                  g.Key.Id,
                  g.Key.Name,
                  Total = g.Select(y => y.subv.SubValueSum).Sum()
                } into y
                orderby y.Total descending
                select y;
    var result = query.Take(10);
