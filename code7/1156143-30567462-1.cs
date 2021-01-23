    [Export(typeof(IResultsRepository))]
    class CustomResultContainer : IResultsRepository
    {
        [ImportingConstructor]
        public CustomResultContainer(IDoNothing nothing)
        {
        }
        public IList<string> GetResults()
        {
            throw new NotImplementedException();
        }
        public string GetSummary()
        {
            throw new NotImplementedException();
        }
    }
    [Export(typeof(IResultsRepository))]
    class ResultContainerWithLogging : IResultsRepository
    {
        [ImportingConstructor]
        public ResultContainerWithLogging(ILogger logger)
        {
        }
        public IList<string> GetResults()
        {
            throw new NotImplementedException();
        }
        public string GetSummary()
        {
            throw new NotImplementedException();
        }
    }
