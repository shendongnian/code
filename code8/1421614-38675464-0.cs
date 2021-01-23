    class TransactionResult
    {
        public List<TransactionReportModel> Items { get; set; }
    
        public int TotalTransaction { get; set; }
        public int OutTransaction { get; set; }
        public int TotalRecord { get; set; }
    }
    
    
    public TransactionResult GetAllTransaction(TransactionSearchModel searchModel)
    {
        IQueryable<TransactionReportModel> result;
        // search
    
        return new TransactionResult
        { 
            Items = result.ToList(),
            TotalTransaction = ...,
            OutTransaction = ...,
            TotalRecord = ...
        };
    }
