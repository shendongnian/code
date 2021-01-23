        var faults = new Subject<DataManagementWorkItem>();
        return m_namespaceManager
            .GetNamespaceConnectionInfoSource(true, drainAndDisable: false)
            .Catch<NamespaceConnectionInfo, Exception>(exc =>
            {
                faults.OnError(exc);
                return Observable.Empty<NamespaceConnectionInfo>();
            })
            .Select(nci => Observable.Defer(() => GetPolicySourceForNamespace(nci)))
            .Merge(maxConcurrentCalls)
            .Where(IsValid)
            .Select(ToWorkItem)
            .Where(o => o != null)
            .Concat(faults);
    }
