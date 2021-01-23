    public class SearchViewModel 
    {
        public SearchResultModel SearchResultModel{ get; set; }
        public SearchCriteriaModel SearchCriteriaModel{ get; set; }
    }
    
    public virtual JsonResult LoadPreviousProductsJson(string model) 
    {    
	    var modelClass = JsonConvert.DeserializeObject<SearchViewModel>(model);
	    var searchResultModel = modelClass.SearchCriteriaModel;
	    var searchCriteriaModel = modelClass.SearchResultModel;
        //... other code
    }
