    public static class BufferExtensions
    {
      public async static Task ClearContentsAsync(this IBuffer buff)
      {
        var writer = new DataWriter(buff.AsStream().AsOutputStream());
        for (var i = 0; i < buff.Capacity; i++)
          writer.WriteByte(42);
        await writer.StoreAsync();
      }
    }
