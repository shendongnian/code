        var alerts = new List<ServiceAlertsEntity>();
        
        var query = new TableQuery<ServiceAlertsEntity>();
        TableContinuationToken continuationToken = null;
        do
        {
            var page = await table.ExecuteQuerySegmentedAsync(query, continuationToken);
            continuationToken = page.ContinuationToken;
            alerts.AddRange(page.Results);
        }
        while (continuationToken != null);
