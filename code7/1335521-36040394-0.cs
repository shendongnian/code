    class SynchronousFilePath: IFilePath
    {
      public string GetAsset(); // natural synchronous implementation
      public Task<string> GetAssetAsync()
      {
        return Task.FromResult(GetAsset());
      }
    }
