    public abstract class SearchQuery 
    {
        public Type ResultType { get; set; }
        public SearchQuery(Type searchResultType)
        {
            ResultType = searchResultType;
        }
    }
