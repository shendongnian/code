    var x = sampleData
        .GroupBy(x => x.AccessGroupId)
        .Select(accessGroup => new 
        { 
            AccessGroupId = accessGroup.Key, 
            TopThreeDocs = accessGroup.GroupBy(x => x.DocumentId)
                                      .OrderyByDescending(subg => subg.Count())
                                      .Take(3)
        })
        .SelectMany(x => x.TopThreeDocs.Select(y => new
        {
            x.AccessGroupId,
            DocumentId = y.Key,
            Count = y.Count()
        });
