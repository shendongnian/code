    var groupedWebPerformances = webPerformances.GroupBy(performance => performance.ProductionSeasonId);
    var webPerformancesDictionary = groupedWebPerformances .ToDictionary(grouping => SheddProduction.GetOurProduction(grouping.Key), grouping => grouping.ToList());
    IEnumerable<WebProduction> webProductions = webPerformancesDictionary.Select(perfsByProduction =>
                    new WebProduction
                    {
                        ProductionSeasonId = perfsByProduction.Key.ProductionSeasonNumber,
                        Duration = perfsByProduction.Key.Duration,
                        Title = perfsByProduction.Key.UserFriendlyTitle,
                        Synopsis = perfsByProduction.Key.UserFriendlySynopsis,
                        ThumbnailImage = perfsByProduction.Key.PreviewImage,
                        Performances = perfsByProduction.Value
                    });
