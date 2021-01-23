    private async Task<BatchResult> FetchBatches()
    {
        var result = new List<BatchResult>();
        foreach (var batch in _batchesList)
        {
            result.Add(await Task.Factory.StartNew(() => batch.Fetch())); //this is calling the external services
        }
        return result;
    }
