        sampleData
                .GroupBy(a=>new{a.AccessGroupId,a.DocumentId})
			    .Select(a=>new{ Count=a.Count(),a.Key.AccessGroupId,a.Key.DocumentId })
                .OrderByDescending(a=>a.Count)
                .GroupBy(a=>a.AccessGroupId)
			    .Select(a=>new{ AccessGroupId = a.Key, Values = a.Take(3)});
