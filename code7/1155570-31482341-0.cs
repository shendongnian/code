    public class SearchController : Controller
    {
        private readonly ISearchResultsService _resultsService;
    
        public SearchController(ISearchResultsService resultsService)
        {         
            _resultsService = resultsService;
        }
    }
