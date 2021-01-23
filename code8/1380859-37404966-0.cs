    var tasks = job.Tasks ?? Enumerable.Empty<Task>();
    var transactions = tasks
        .Where(t => t.TaskCharges != null)
        .SelectMany(t => t.TaskCharges)
        .Where(tc => tc.IsAccepted)
        .Select(tc => new Transaction(...));
