    var days = 5;
    var partitionKey = DateTime.UtcNow.AddDays(-days).Ticks.ToString("D18")
    var query = new TableQuery<MyEntity>().Where(
      TableQuery.GenerateFilterCondition(
        "PartitionKey",
        QueryComparisons.GreaterThanOrEqual,
        partitionKey
      )
    );
