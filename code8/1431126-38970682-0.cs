    var results = repList
       .GroupBy(x => "all")
       .Select(x=> new {
            ProjectId = x.First().ProjectId,
            Name = x.First().Name,   
			ProjectName =  x.First().ProjectName,
            LevelId = x.First().LevelId,
            Minutes =  x.Sum(s=>s.Minutes),
            Hours =  x.Sum(s=>s.Hours ),
            ExtraMinutes =  x.Sum(s=>s.ExtraMinutes),
			ExtraHours = x.Sum(s=>s.ExtraHours)
        });
