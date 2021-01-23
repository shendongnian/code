    var results = repList.GroupBy(x=> new {x.ProjectId, x.ProjectName, LevelId })
           .Select(x=> new  // or create new ReportList object.
            {
                ProjectId = x.Key.ProjectId,  
                ProjectName =  x.Key.ProjectName,
                Name = x.First().Name,   // I assume it is first one as per example, modify if you want.
                LevelId = x.Key.LevelId,
                Minutes =  x.Sum(s=>s.Minutes),
                Hours =  x.Sum(s=>s.Hours ),
                ExtraMinutes =  x.Sum(s=>s.ExtraMinutes ),               
                ExtraHours =  x.Sum(s=>s.ExtraHours)                                 
            })
           .ToList() ;
 
