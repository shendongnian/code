    var totalPostTask = context.Campaigns.SumAsync(c => c.Posts);
    var averagePostTask = context.Campaigns.AverageAsync(c => c.Posts);
    var totalImpressionTask = context.Campaigns.SumAsync(c => c.Impressions);
    var averageImpressionsTask = context.Campaigns.AverageAsync(c => c.Impressions);
    await Task.WhenAll(
        totalPostTask, 
        averagePostTask, 
        totalImpressionTask, 
        averageImpressionsTask);
        
    var data = new CampaignData()
    {
        TotalPost = totalPostTask.Result,
        AveragePost = averagePostTask.Result,
        TotalImpression = totalImpressionTask.Result,
        AverageImpressions = averageImpressionsTask.Result,
    };
