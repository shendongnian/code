    var ouDataPreparers = new Dictionary<QueryType, Func<DataPreparer>>
    {
        [OuComputers] = () => new DataPreparer
        {
            Data = activeDirectorySearcher.GetOuComputerPrincipals(),
            Attributes = DefaultComputerAttributes
        },
        return ouDataPreparers[QueryType]();
    }
