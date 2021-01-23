    public data[] SomeMethod()
    {
      return Enumerable.Range(0, 100)
          .AsParallel().AsOrdered()
          .Select(GetDataFor).ToArray();
    }
