    public IObservable<DataManagementWorkItem> GetWorkItemSource(int maxConcurrentCalls)
    {
        return Observable.Create<DataManagementWorkItem>((observer) =>
        {
            var faults = new Subject<DataManagementWorkItem>();
            return m_namespaceManager
                .GetNamespaceConnectionInfoSource(true, drainAndDisable: false)
                .Catch<NamespaceConnectionInfo, Exception>(exc =>
                {
                    faults.OnError(exc);
                    return Observable.Empty<NamespaceConnectionInfo>();
                })
                .Take(maxConcurrentCalls)
                .Select(nci => GetPolicySourceForNamespace(nci))
                .Merge()
                .Where(IsValid)
                .Select(ToWorkItem)
                .Where(o => o != null)
                .Finally(() => faults.OnCompleted())
                .Concat(faults)
                .Subscribe(observer);
        });
    }
