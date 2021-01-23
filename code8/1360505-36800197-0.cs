    public async Task DoWorkAndCancel(Func<CancellationToken, Task<bool>> work,
        CancellationTokenSource cts)
    {
      if (!await work(cts.Token))
        cts.Cancel();
    }
    List<Func<CancellationToken, Task<bool>>> allWork = ...;
    var cts = new CancellationTokenSource();
    var tasks = allWork.Select(x => DoWorkAndCancel(x, cts));
    await Task.WhenAll(tasks);
