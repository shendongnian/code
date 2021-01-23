    public Task<FileActionStatus> SaveAsync(path, data)
    {
      return Task.Run<FileActionStatus>(() =>
        {
          File.WriteAllBytes(path, data);
          // don't forget to return your FileActionStatus
        });
    }
