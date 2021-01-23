    List<TestResultGroup> groups = ...
    int rank = 1; 
    var sortedGroups = groups
        .GroupBy(
            gr =>
            {
                var meanResult = gr.Results.FirstOrDefault(res => res.SectionName == "MeanScore");
                return meanResult != null ? meanResult.Score : -1;
        })
        .OrderByDescending(grouping => grouping.Key)
        .SelectMany(grouping =>
            {
                int groupRank = rank++;
                foreach (var group in grouping)
                {
                    group.Rank = groupRank;
                }
                return grouping;
            })
         .ToArray(); // or ToList
 
