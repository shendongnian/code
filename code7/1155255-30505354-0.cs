    public async Task ExecuteAsync()
    {
      await Task.WhenAll(producer.ProduceAsync(), consumer.ConsumeAsync())
          .ConfigureAwait(false);
    }
