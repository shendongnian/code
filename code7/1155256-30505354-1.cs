    public async Task ExecuteAsync()
    {
      await Task.WhenAll(Task.Run(() => producer.Produce()), Task.Run(() => consumer.Consume()))
          .ConfigureAwait(false);
    }
