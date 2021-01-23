    public static Task<IEnumerable<SftpFile>> ListDirectoryAsync(this SftpClient @this, string path)
    {
      var tcs = new TaskCompletionSource<IEnumerable<SftpFile>>();
      @this.BeginListDirectory(path, asyncResult =>
      {
        try
        {
          tcs.TrySetResult(@this.EndListDirectory(asyncResult));
        }
        catch (OperationCanceledException)
        {
          tcs.TrySetCanceled();
        }
        catch (Exception ex)
        {
          tcs.TrySetException(ex);
        }
      }, null);
      return tcs.Task;
    }
