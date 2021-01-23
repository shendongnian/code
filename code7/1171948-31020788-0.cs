    async Task IRunBeforeEachRequest.Execute()
    {
      _HttpContext.Items[IdentityContextTransactionKey] = _IdentityContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
      _HttpContext.Items[TravellersContextTransactionKey] = _TravellersContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);
    }
