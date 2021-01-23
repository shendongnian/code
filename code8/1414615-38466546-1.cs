    var results = (from entry in sampleData
                    group entry by new { entry.AccessGroupId, entry.DocumentId } into g
                    select new
                    {
                        AccessGroupId = g.Key.AccessGroupId,
                        DocumentId = g.Key.DocumentId,
                        Count = g.Count()
                    }).OrderByDescending(x => x.Count)
                    .GroupBy(x => x.AccessGroupId)
                    .SelectMany(x => x.Take(3));
