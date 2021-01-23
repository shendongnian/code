	var list = new List<MyEntity>();
	var table = tableClient.GetTableReference("table");
    var tableQuery = new TableQuery<UserEntity>();
	TableContinuationToken continuationToken = null;
	do
	{
		var query = await table.ExecuteQuerySegmentedAsync(
			tableQuery, continuationToken).ConfigureAwait(false);
		list.AddRange(query.Results);
		continuationToken = query.ContinuationToken;
	} while (continuationToken != null);
