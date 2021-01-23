    private readonly object _syncObject = new object();
    public void SendData(BlockingCollection<byte[]> data)
    {
      lock (_syncObject)
      {
        byte[] buffer;
        
        while (data.TryTake(out buffer, TimeSpan.FromSeconds(1)))
        {
          // Send the data
        }
      }
    }
