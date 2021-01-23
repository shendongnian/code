    var filterBuilder = new FilterDefinitionBuilder<WorkerSession>();
    var filter = filterBuilder.Empty;
    
    if (query.IsOngoing.HasValue)
    {
        filter = filterBuilder.And(query.IsOngoing.Value
            ? new ExpressionFilterDefinition<WorkerSession>(session => session.CompletedOn == null)
            : new ExpressionFilterDefinition<WorkerSession>(session => session.CompletedOn != null));
    }
    
    var filtered = await workerSessions.Find(filter).ToListAsync();
