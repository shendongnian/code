    [Route(FullControllerPath + "/TransactionTypes")]
    public IHttpActionResult GetTransactionTypes(ODataQueryOptions<AccountAction> queryOptions, bool addCols, int? skip, int? take)
    {
        using (AccountActionManagement _accountActionManage = new AccountActionManagement(this.GenerateInformation()))
        {
            _accountActionManage.SetTraslationList("DATASTRUCT-CONFIG-ACCOUNTACTIONTRANSACTIONTYPE", language);
    
            // Query composition
            IQueryable<TransactionType> query = queryOptions.ApplyTo(_accountActionManage.GetTypeAsQueryable<AccountAction()
                                   .SelectMany(aa => aa.TransactionTypes)
                                   .Include(aa =>      aa.AccountActionForDefaultTransactionType.DefaultTransactionType))
                                   .OfType<TransactionType>();
    
    
            var queryData = query.Select(tt => new
                            {
                                Id = tt.Id,
                                Name = tt.Name,
                                Operation = tt.Operation,
                                Type = tt.Type,
                                Default = tt.AccountActionForDefaultTransactionType != null && 
                                          tt.AccountActionForDefaultTransactionType.DefaultTransactionType.Id == tt.Id,
                                Version = tt.AccountActionForDefaultTransactionType.Version
                            });
            // Get count
            int totalRows = queryData.Count();
    
            // Get biggest version in query
            var maxVersion = queryData.Max(i => i.Version);
    
            // Get data from database
            var queryResult = queryOptions.OrderBy == null 
                                  ? queryData.OrderBy(i => i.Id)
                                             .Skip(skip ?? 0)
                                             .Take(take ?? totalRows)
                                             .ToList() 
                                  : queryData.Skip(skip ?? 0)
                                             .Take(take ?? totalRows)
                                             .ToList();
    ...}}
