    List<List<int[]>> iterationResults = new List<List<int[]>>();
    for (int iteration = 0; iteration < 6; iteration++)
    {
        iterationResults.Add(collection.OrderBy(item => Guid.NewGuid())
                    .Select((item, index) => new { Item = item, GroupKey = index % 4 })
                    .GroupBy(item => item.GroupKey)
                    .Select(group => group.Select(item => item.Item).ToArray()).ToList());
    }
