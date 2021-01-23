    public IObservable<DataManagementWorkItem> GetWorkItemSource(int maxConcurrentCalls)
    {
        // wrap within Observable.Defer
        // so that each new subscription
        // gets its own Error subject
        return Observable.Defer(() =>
        {
            var error = new AsyncSubject<DataManagementWorkItem>();
            return m_namespaceManager
                .GetNamespaceConnectionInfoSource(true, drainAndDisable: false)
                .Catch(err =>
                {
                    error.OnNext(err);
                    return Observable.Empty<NamespaceConnectionInfo>();
                })
                .Finally(error.OnCompleted)
                .Select(nci => Observable.Defer(() => GetPolicySourceForNamespace(nci)))
                .Merge(maxConcurrentCalls)
                .Where(IsValid)
                .Select(ToWorkItem)
                .Where(o => o != null)
                .Concat(error);
        });
    }
