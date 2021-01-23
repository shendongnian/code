    public Task<data[]> SomeMethodAsync()
    {
      return Task.WhenAll(
          Enumerable.Range(0, 100).Select(GetDataForAsync)
      );
    }
