    using (var session = docStore.OpenSession()) {
        var categoryUsageCounts = session
            .Query<CategoryUsageCount, UsageCountByCategory>()
            .ToList();
    }
    
