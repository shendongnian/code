    public async Task<IEnumerable<BrokeredMessage>[]> GetCombinedResultsAsync()
    {
                var job = () => ServiceBus.TrackerClient.ReceiveBatchAsync(BatchLimit);
                Task<IEnumerable<BrokeredMessage>> task1 = _retryPolicy.ExecuteAsync<IEnumerable<BrokeredMessage>>(job);
                Task<IEnumerable<BrokeredMessage>> task2 = _retryPolicy.ExecuteAsync<IEnumerable<BrokeredMessage>>(job);
                IEnumerable<BrokeredMessage>[] results = await Task.WhenAll<IEnumerable<BrokeredMessage>>(task1, task2);
                return results;
    }
