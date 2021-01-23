    public Task<ReadResult> ReadAsync(byte[] buffer)
    {
      var tcs = new TaskCompletionSource<ReadResult>();
      GCHandle pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
      IntPtr bytesToRead = Marshal.AllocHGlobal(sizeof(long));
      Marshal.WriteInt64(bytesToRead, buffer.Length);
      FsAsyncInfo asyncInfo = new FsAsyncInfo();
      asyncInfo.Callback = (int status) =>
      {
        tcs.TrySetResult(new ReadResult
        {
          ErrorCode = status;
          BytesRead = (int)Marshal.ReadInt64(bytesToRead);
        });
        pinnedBuffer.Free();
        Marshal.FreeHGlobal(bytesToRead);
      };
      NativeMethods.FsReadStream(pinnedBuffer.AddrOfPinnedObject(), bytesToRead, ref asyncInfo);
      return tcs.Task;
    }
