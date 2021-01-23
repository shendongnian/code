    public async Task<IEnumerable<DiagnosticsInfo>> Get()
    {
        var task1 = GetDiagnosticsInfo1();
        var task2 = GetDiagnosticsInfo2();
        var task3 = GetDiagnosticsInfo3();
        return await Task.WhenAll(task1, task2, task3);
    }
