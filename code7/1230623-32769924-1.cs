    List<OurPerformance> validPerformances = package.TimeFilteredValidPerformances(visitDateAndTime).ToList();
    
    List<WebPerformance> webPerformances = performanceGroup.RegularNonPassedPerformances
                .Where(performance => validPerformances.Select(perf => perf.PerformanceId).Contains(performance.PerformanceId))                
                .Select(performance =>
                    new WebPerformance
                    {
                        Date = performance.PerformanceDate.ToJavaScriptDateString(),
                        PerformanceId = performance.PerformanceId,
                        Title = performance.UserFriendlyTitle,
                        ProductionSeasonId = performance.ProductionSeasonId,
                        AvailableCount = performance.AvailableCount
                    })
                 .ToList();
    
    List<WebProduction> webProductions = webPerformances
                .GroupBy(performance => performance.ProductionSeasonId)
                .ToDictionary(grouping => SheddProduction.GetOurProduction(grouping.Key), grouping => grouping.ToList())
                .Select(perfsByProduction =>
                    new WebProduction
                    {
                        ProductionSeasonId = perfsByProduction.Key.ProductionSeasonNumber,
                        Duration = perfsByProduction.Key.Duration,
                        Title = perfsByProduction.Key.UserFriendlyTitle,
                        Synopsis = perfsByProduction.Key.UserFriendlySynopsis,
                        ThumbnailImage = perfsByProduction.Key.PreviewImage,
                        Performances = perfsByProduction.Value
                    })
                .ToList();
