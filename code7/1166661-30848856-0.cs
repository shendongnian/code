    public static void DoWork(work, cancellationToken)
    {
      while (work.IsWorking)
      {
        cancellationToken.ThrowIfCancellationRequested();
        work.DoNextWork();
      }
    }
