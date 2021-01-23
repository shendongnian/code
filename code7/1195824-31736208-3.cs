    m_namespaceManager
        .GetNamespaceConnectionInfoSource(true, drainAndDisable: false)
        .Catch<NamespaceConnectionInfo, Exception>(exc =>
        {
            faults.OnError(exc);
            return Observable.Empty<NamespaceConnectionInfo>();
        })
        .Count()
