      for (...)
      {
        tasks.Add(BothMethodsAsync(items));
      }
      await Task.WhenAll(tasks);
    async Task BothMethodsAsync(... items)
    {
      await FirstMethodAsync(items);
      await items.SecondMethodAsync(item => item.SomeProperty);
    }
