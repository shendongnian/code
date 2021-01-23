    IEnumerable<IGrouping<string, WebProduction>> groupedPerformances 
        = webPerformances.GroupBy(performance => performance.ProductionSeasonId);
    
    var dictionary = new Dictionary<string, List<WebProduction>>();
    foreach (IGrouping<string, WebProduction> grouping in groupedPerformances)
    {
        var group = new List<WebProduction>();
        foreach (WebProduction webProduction in grouping)
            group.Add(webProduction);
    
        dictionary.Add(grouping.Key, group);
    }
    
    var result = new List<WebProduction>();
    foreach (KeyValuePair<string, List<WebProduction>> item in dictionary)
    {
        var wp = new WebProduction
        {
            ProductionSeasonId = perfsByProduction.Key.ProductionSeasonNumber,
            Duration = perfsByProduction.Key.Duration,
            Title = perfsByProduction.Key.UserFriendlyTitle,
            Synopsis = perfsByProduction.Key.UserFriendlySynopsis,
            ThumbnailImage = perfsByProduction.Key.PreviewImage,
            Performances = perfsByProduction.Value
        };
        result.Add(wp);
    }
