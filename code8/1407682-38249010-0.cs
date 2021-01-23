    public struct ProgressReport
    {
      public double Progress { get; set; }
      public double FileSize { get; set; }
    }
    async Task FileTransferAsync(IProgress<ProgressReport> progress)
    {
      ...
      if (progress != null)
      {
        progress.Report(new ProgressReport
        {
          Progress = (double)i,
          FileSize = fileSize
        });
      }
      ...
    }
