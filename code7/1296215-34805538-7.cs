    KeywordQuery query = new KeywordQuery(ctx);
    query.QueryText = "contentclass:\"STS_Site\"";
    query.RowLimit = 500;//max row limit is 500 for KeywordQuery
    query.EnableStemming = true;
    query.TrimDuplicates = false;
    SearchExecutor searchExecutor = new SearchExecutor(ctx);
    ClientResult<ResultTableCollection> results = searchExecutor.ExecuteQuery(query);
    ctx.ExecuteQuery();
    var data = results.Value.SelectMany(rs => rs.ResultRows.Select(r => r["Path"])).ToList();
     
