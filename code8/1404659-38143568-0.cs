    public class SearchViewModel 
    {
        public SearchResultModel rmodel { get; set; }
        public SearchCriteriaModel cmodel  { get; set; }
    }
    
    public virtual JsonResult LoadPreviousProductsJson(string model) 
    {    
	    var modelClass = JsonConvert.DeserializeObject<SearchViewModel>(model);
	    var searchResultModel = modelClass.SearchResultModel;
	    var searchCriteriaModel = modelClass.SearchCriteriaModel;
        //... other code
    }
