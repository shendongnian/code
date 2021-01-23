    List<TestResultGroup> groups = ...
    // group test result groups by the same score and sort
    var sameScoreGroups = groups.GroupBy(
        gr =>
        {
            var meanResult = gr.Results.FirstOrDefault(res => res.SectionName == "MeanScore");
            return meanResult != null ? meanResult.Score : -1;
        })
        .OrderByDescending(gr => gr.Key);
    int rank = 1;
    foreach (var sameScoreGroup in sameScoreGroups)
    {
       foreach (var group in sameScoreGroup)
       {
          group.Rank = rank;
       }
       rank++;
    }
    // to obtain sorted groups:
    var sortedGroups = groups.OrderByDescending(gr => gr.Rank).ToArray(); 
