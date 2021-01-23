    public async Task<int> MaxAsync(Task<int>[] my_ints)
    {
      int[] ints = await Task.WhenAll(my_ints);
      return ints.Where(i => i % 2 != 0).Max();
    }
