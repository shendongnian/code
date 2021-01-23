    static CancellationTokenSource _cts;
    private static async Task ProcessCaseAsync(CaseObject caseObject)
    {
      if (_cts != null)
        _cts.Cancel();
      _cts = new CancellationTokenSource();
      await Task.Run(() => ProcessCase(caseObject, _cts.Token));
    }
