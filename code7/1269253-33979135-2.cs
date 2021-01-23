    public Task CreateAsync(QsaasUser<TLogin> user)
        {
            return Task.Factory.StartNew(() => {
                   var session = NHibertnateSessionProvidser.SessionFactory.GetCurrentSession();
                    session.Save(user);
            }).ContinueWith(ex => Trace.TraceError(ex?.Exception?.Message ?? "Strange task fault"), TaskContinuationOptions.OnlyOnFaulted);
        }
