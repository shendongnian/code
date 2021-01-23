    public List<SearchResult> GetSearchResults()
    {
    	string criteria = string.Empty;
    	if (HttpContext.Current.Request["txtCriteria"] != null)
    	{
    		criteria = HttpContext.Current.Request["txtCriteria"];
    	}
    
    	List<SearchResult> searchResults = new List<SearchResult>();
    	searchResults.Add(new SearchResult() { Result = "trial 1 " + criteria });
    	searchResults.Add(new SearchResult() { Result = "trial 2 " + criteria });
    
    	return searchResults;
    }
    
    protected void btnPostSearch_Click(object sender, EventArgs e)
    {
    	myGridView.DataBind();
    }
