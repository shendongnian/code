    using System.Collections.Async;
    public async Task<List<Keyword>> DoWord(List<string> keywords)
    {
        var keywordResults = new ConcurrentBag<Keyword>();
        await keywords.ParallelForEachAsync(async keyword =>
        {
            try
            {
                var result = await Work(keyword);
                keywordResults.Add(result);
            }
            catch (AggregateException ae)
            {
                foreach (Exception innerEx in ae.InnerExceptions)
                {
                    log.ErrorFormat("Core threads exception: {0}", innerEx);
                }
            }
        }, maxDegreeOfParallelism: 8);
        return keywordResults.ToList();
    }
