    public async Task<List<LogDetail>> GetLogsOfTypeForCase(int caseId, LoggType logType, CancellationToken token)
    {
      ...
            }).ToListAsync(token);
      ...
    }
    protected override async void Load()
    {
      this.CaseLogs = await this.dataAdapter.GetLogsOfTypeForCase(this.CaseId, LoggType.S, this.CancellationTokenSource.Token);
    }
