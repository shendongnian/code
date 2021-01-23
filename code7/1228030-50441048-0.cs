    public void LogTimeTaken(string taskType, string eventType, long duration)
    {
        var metric = string.Format("Custom/{0}_{1}", taskType, eventType);
        NewRelic.Api.Agent.NewRelic.RecordResponseTimeMetric(metric, duration);
    }
