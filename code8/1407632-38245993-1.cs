    var ouDataPreparers = new Dictionary<QueryType, Lazy<DataPreparer>>
    {
        [OuComputers] = new Lazy<DataPreparer>(() => new DataPreparer
        {
            Data = activeDirectorySearcher.GetOuComputerPrincipals(),
            Attributes = DefaultComputerAttributes
        }),
        return ouDataPreparers[QueryType].Value;
    }
