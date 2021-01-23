    var processedResult = repList.GroupBy(x => x.ProjectId)
            .Select(x => new ReportList
            {
                ProjectId = x.Key,
                ProjectName = x.First().ProjectName, //As per your example it is first row data
                Name = x.First().Name,   //As per your example it is first row data
                LevelId = x.First().LevelId,
                Minutes = x.Sum(s => s.Minutes),
                Hours = x.Sum(s => s.Hours),
                ExtraMinutes = x.Sum(s => s.ExtraMinutes),
                ExtraHours = x.Sum(s => s.ExtraHours)
            }).ToList();
