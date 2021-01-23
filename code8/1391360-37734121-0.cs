    var result = ctx.Entity.GroupBy(u => new { 
       u.UserId,
       u.DeptId,
       u.DeptName
    }).ToList().Select(grouped => new { 
        GroupKey = grouped.Key,
        DeptNames => string.Join(",", grouped.Select(gr => gr.DependentName)) 
    });
