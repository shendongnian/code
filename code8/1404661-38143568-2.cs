    public class SearchViewModel 
    {
        public SearchResultModel rmodel { get; set; }
        public SearchCriteriaModel cmodel  { get; set; }
    }
    
    public virtual JsonResult LoadPreviousProductsJson(string model) 
    {    
	    var modelClass = JsonConvert.DeserializeObject<SearchViewModel>(model);
	    var searchResultModel = JsonConvert.DeserializeObject<SearchCriteriaModel>(modelClass.SearchCriteriaModel);
	    var searchCriteriaModel = JsonConvert.DeserializeObject<SearchResultModel >(modelClass.SearchResultModel);
        //... other code
    }
